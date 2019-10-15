using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountCore.BussinessLayer.Employee;
using Microsoft.AspNetCore.Mvc;

using Contracts = AccountCore.Contract.Models;

namespace AccountCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Contracts.Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            await _employeeService.AddAsync(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Contracts.Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            await _employeeService.UpdateAsync(employee);
            return View("Index");
        }
    }
}