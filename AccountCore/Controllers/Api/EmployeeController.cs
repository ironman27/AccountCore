using System.Threading.Tasks;
using AccountCore.BussinessLayer.Employee;
using Microsoft.AspNetCore.Mvc;

namespace AccountCore.Controllers.Api
{
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee(int draw, int start, int length, [Bind(Prefix = "search[value]")] string search)
        {
            return Ok(await _employeeService.GetDataAsync(draw, search, start, length));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok(new { success = true, message = "Delete success." });
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> RestoreCustomer([FromRoute] int id)
        //{
        //    await _employeeService.RestoreAsync(id);
        //    return Ok(new { success = true, message = "Restore success." });
        //}
    }
}