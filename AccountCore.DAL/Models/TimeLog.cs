using System;

namespace AccountCore.DAL.Models
{
    public class TimeLog
    {
        public int TimeLogId { get; set; }
        public DateTime DateTime { get; set; }
        public int Hours { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
