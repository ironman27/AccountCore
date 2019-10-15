using AccountCore.Contract.Models;
using System.Threading.Tasks;
using Contracts = AccountCore.Contract.Models;

namespace AccountCore.BussinessLayer.Employee
{
    public interface IEmployeeService
    {
        Task<GridData<Contracts.Employee>> GetDataAsync(int draw, string search, int skip, int take);
        Task<Contracts.Employee> GetAsync(int id);

        Task<int> AddAsync(Contracts.Employee customer);
        Task UpdateAsync(Contracts.Employee customer);

        Task DeleteAsync(int id);
        //Task RestoreAsync(int id);
    }
}
