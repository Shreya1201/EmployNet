using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Payrolltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payroll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: true),
                    Deductions = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: true),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payroll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payroll_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_EmployeeId",
                table: "Payroll",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payroll");
        }
    }
}
