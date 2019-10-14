using AccountCore.Contract.Models;
using System;

namespace AccountCore.Contract
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int SalaryPerHour { get; set; }
        public Position Position { get; set; }

        //public string ManagerName { get; set; }

    }
}
