using System;
using System.Collections.Generic;
using System.Text;

namespace AccountCore.DAL.Models
{
    public class Manager : Person
    {
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
