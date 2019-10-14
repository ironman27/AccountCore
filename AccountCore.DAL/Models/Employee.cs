using AccountCore.DAL.Models;
using System.Collections.Generic;

namespace AccountCore.DAL
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int SalaryPerHour { get; set; }
        public Position Position { get; set; }
        public Employee Manager { get; set; }
        public int? ManagerId { get; set; }
        public virtual ICollection<TimeLog> TimeLogs { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
