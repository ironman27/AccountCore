using AccountCore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountCore.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Manager> Managers { get; set; }

        public virtual DbSet<TimeLog> TimeLogs { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<Manager>().ToTable("Managers");

            modelBuilder.Entity<Employee>()
               .HasOne(v => v.Manager)
               .WithMany(b => b.Employees)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimeLog>()
              .HasOne(v => v.Employee)
              .WithMany(b => b.TimeLogs)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Manager>().HasData(
                new Manager { PersonId = 1, Name = "Tom", SalaryPerHour = 15 },
                new Manager { PersonId = 2, Name = "Fred", SalaryPerHour = 15 }
             );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { PersonId = 11, Name = "Sam", SalaryPerHour = 10, ManagerId = 1 },
                new Employee { PersonId = 12, Name = "Dan", SalaryPerHour = 11, ManagerId = 1 },

                new Employee { PersonId = 21, Name = "Ken", SalaryPerHour = 9, ManagerId = 2 },
                new Employee { PersonId = 22, Name = "Ban", SalaryPerHour = 8, ManagerId = 2 },
                new Employee { PersonId = 23, Name = "Ted", SalaryPerHour = 7, ManagerId = 2 }
                );
        }
    }
}
