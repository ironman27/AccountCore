using AccountCore.BussinessLayer.Employee;
using AccountCore.Contract.Models;
using AccountCore.DAL;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contract = AccountCore.Contract;
using Entities = AccountCore.DAL;

namespace AccountCore.BussinessLayer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Contract.Employee employee)
        {
            var result = _context.Employees.Add(_mapper.Map<Contract.Employee, Entities.Employee>(employee));
            await _context.SaveChangesAsync();

            return result.Entity.EmployeeId;
        }

        public async Task DeleteAsync(int id)
        {
            var employeeEntity = _context.Employees.Find(id);
            _context.Employees.Remove(employeeEntity);

            await _context.SaveChangesAsync();
        }

        public async Task<Contract.Employee> GetAsync(int id)
        {
            return  _mapper.Map<Entities.Employee, Contract.Employee>(await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id));
        }

        public async Task<GridData<Contract.Employee>> GetDataAsync(int draw, string search, int skip, int take)
        {
            var result = new GridData<Contract.Employee> { Draw = draw };

            async Task LoadRecordsTotal() => result.RecordsTotal = await GetCountAsync(null);
            async Task LoadRecordsFiltered() => result.RecordsFiltered = await GetCountAsync(search);
            async Task LoadData() => result.Data = await GetAsync(search, skip, take);

            await Task.WhenAll(LoadRecordsTotal(), LoadRecordsFiltered(), LoadData());

            return result;
        }

        private IQueryable<Entities.Employee> Query(string search, bool order)
        {
            var result = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                result = result.Where(c => c.Name.Contains(search));

            if (order)
            {
                result = result.OrderBy(c => c.EmployeeId);
            }

            return result;
        }

        private async Task<int> GetCountAsync(string search)
        {
            return await Query(search, false).CountAsync();
        }

        private async Task<List<Contract.Employee>> GetAsync(string search, int skip, int take)
        {
            return _mapper.Map<List<Entities.Employee>, List<Contract.Employee>>(await Query(search, true).Skip(skip).Take(take).ToListAsync());
        }

        //public Task RestoreAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task UpdateAsync(Contract.Employee employee)
        {
            var entity = await _context.Employees.FirstAsync(c => c.EmployeeId == employee.EmployeeId);
            _mapper.Map(employee, entity);

            await _context.SaveChangesAsync();
        }

        public decimal CalculateSalary(Entities.Employee employee, DateTime startDateTime, DateTime endDateTime)
        {
            return employee.TimeLogs.Where(t => t.DateTime >= startDateTime && t.DateTime <= endDateTime).Sum(timeLog => timeLog.Hours * employee.SalaryPerHour);
        }

    }
}
