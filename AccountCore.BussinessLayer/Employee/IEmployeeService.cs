using AccountCore.Contract.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contract = AccountCore.BussinessLayer.Employee;

namespace AccountCore.BussinessLayer.Employee
{
    public interface IEmployeeService
    {
        Task<GridData<Contract.Employee>> GetDataAsync(int draw, string search, int skip, int take);
        Task<Contract.Employee> GetAsync(int id);

        Task<int> AddAsync(Contract.Employee customer);
        Task UpdateAsync(Contract.Employee customer);

        Task DeleteAsync(int id);
        //Task RestoreAsync(int id);
    }
}
