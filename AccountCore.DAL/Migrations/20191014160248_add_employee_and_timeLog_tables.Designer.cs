﻿// <auto-generated />
using System;
using AccountCore.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccountCore.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191014160248_add_employee_and_timeLog_tables")]
    partial class add_employee_and_timeLog_tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountCore.DAL.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ManagerId");

                    b.Property<string>("Name");

                    b.Property<int>("Position");

                    b.Property<int>("SalaryPerHour");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Name = "Tom",
                            Position = 1,
                            SalaryPerHour = 15
                        },
                        new
                        {
                            EmployeeId = 2,
                            Name = "Fred",
                            Position = 1,
                            SalaryPerHour = 15
                        },
                        new
                        {
                            EmployeeId = 11,
                            ManagerId = 1,
                            Name = "Sam",
                            Position = 1,
                            SalaryPerHour = 10
                        },
                        new
                        {
                            EmployeeId = 12,
                            ManagerId = 1,
                            Name = "Dan",
                            Position = 1,
                            SalaryPerHour = 11
                        },
                        new
                        {
                            EmployeeId = 21,
                            ManagerId = 2,
                            Name = "Ken",
                            Position = 1,
                            SalaryPerHour = 9
                        },
                        new
                        {
                            EmployeeId = 22,
                            ManagerId = 2,
                            Name = "Ban",
                            Position = 1,
                            SalaryPerHour = 8
                        },
                        new
                        {
                            EmployeeId = 23,
                            ManagerId = 2,
                            Name = "Ted",
                            Position = 1,
                            SalaryPerHour = 7
                        });
                });

            modelBuilder.Entity("AccountCore.DAL.TimeLog", b =>
                {
                    b.Property<int>("TimeLogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("Hours");

                    b.HasKey("TimeLogId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeLogs");
                });

            modelBuilder.Entity("AccountCore.DAL.Employee", b =>
                {
                    b.HasOne("AccountCore.DAL.Employee", "Manager")
                        .WithMany("Employees")
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("AccountCore.DAL.TimeLog", b =>
                {
                    b.HasOne("AccountCore.DAL.Employee", "Employee")
                        .WithMany("TimeLogs")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
