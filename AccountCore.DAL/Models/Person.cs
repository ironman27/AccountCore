using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountCore.DAL.Models
{
    public abstract class Person
    {
        [Key]
        public int PersonId { get; set; }

        public string Name { get; set; }

        public int SalaryPerHour { get; set; }

        public virtual ICollection<TimeLog> TimeLogs { get; set; }
    }
}
