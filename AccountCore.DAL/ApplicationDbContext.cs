using Microsoft.EntityFrameworkCore;

namespace AccountCore.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<TimeLog> TimeLogs { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee { EmployeeId = 1, Name = "Tom", Position = Models.Position.Manager, SalaryPerHour = 15 },
               new Employee { EmployeeId = 2, Name = "Fred", Position = Models.Position.Manager, SalaryPerHour = 15 },

               new Employee { EmployeeId = 11, Name = "Sam", Position = Models.Position.Manager, SalaryPerHour = 10, ManagerId = 1 },
               new Employee { EmployeeId = 12, Name = "Dan", Position = Models.Position.Manager, SalaryPerHour = 11, ManagerId = 1 },

               new Employee { EmployeeId = 21, Name = "Ken", Position = Models.Position.Manager, SalaryPerHour = 9, ManagerId = 2 },
               new Employee { EmployeeId = 22, Name = "Ban", Position = Models.Position.Manager, SalaryPerHour = 8, ManagerId = 2 },
               new Employee { EmployeeId = 23, Name = "Ted", Position = Models.Position.Manager, SalaryPerHour = 7, ManagerId = 2 }
               );
        }
    }
}
