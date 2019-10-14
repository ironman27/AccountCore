using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountCore.DAL.Migrations
{
    public partial class add_employee_and_timeLog_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SalaryPerHour = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    ManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeLogs",
                columns: table => new
                {
                    TimeLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLogs", x => x.TimeLogId);
                    table.ForeignKey(
                        name: "FK_TimeLogs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "ManagerId", "Name", "Position", "SalaryPerHour" },
                values: new object[] { 1, null, "Tom", 1, 15 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "ManagerId", "Name", "Position", "SalaryPerHour" },
                values: new object[] { 2, null, "Fred", 1, 15 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "ManagerId", "Name", "Position", "SalaryPerHour" },
                values: new object[,]
                {
                    { 11, 1, "Sam", 1, 10 },
                    { 12, 1, "Dan", 1, 11 },
                    { 21, 2, "Ken", 1, 9 },
                    { 22, 2, "Ban", 1, 8 },
                    { 23, 2, "Ted", 1, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLogs_EmployeeId",
                table: "TimeLogs",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeLogs");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
