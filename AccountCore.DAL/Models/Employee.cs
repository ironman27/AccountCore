using System.Collections.Generic;

namespace AccountCore.DAL.Models
{
    public class Employee : Person
    {
        public Manager Manager { get; set; }

        public int? ManagerId { get; set; }
    }
}
