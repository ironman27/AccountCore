using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountCore.DAL.Migrations
{
    public partial class add_Employee_Manager_Timelog_Person_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SalaryPerHour = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_People_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "People",
                        principalColumn: "PersonId",
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
                    EmployeeId = table.Column<int>(nullable: false),
                    ManagerPersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLogs", x => x.TimeLogId);
                    table.ForeignKey(
                        name: "FK_TimeLogs_People_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeLogs_People_ManagerPersonId",
                        column: x => x.ManagerPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Discriminator", "Name", "SalaryPerHour" },
                values: new object[] { 1, "Manager", "Tom", 15 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Discriminator", "Name", "SalaryPerHour" },
                values: new object[] { 2, "Manager", "Fred", 15 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Discriminator", "Name", "SalaryPerHour", "ManagerId" },
                values: new object[,]
                {
                    { 11, "Employee", "Sam", 10, 1 },
                    { 12, "Employee", "Dan", 11, 1 },
                    { 21, "Employee", "Ken", 9, 2 },
                    { 22, "Employee", "Ban", 8, 2 },
                    { 23, "Employee", "Ted", 7, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_ManagerId",
                table: "People",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLogs_EmployeeId",
                table: "TimeLogs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLogs_ManagerPersonId",
                table: "TimeLogs",
                column: "ManagerPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeLogs");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
