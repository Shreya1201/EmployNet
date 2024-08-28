using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Leave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApprovals_AspNetUsers_ManagerId",
                table: "LeaveApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApprovals_LeaveRequests_LeaveRequestId",
                table: "LeaveApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_UserId",
                table: "LeaveRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveApprovals",
                table: "LeaveApprovals");

            migrationBuilder.RenameTable(
                name: "LeaveRequests",
                newName: "LeaveRequest");

            migrationBuilder.RenameTable(
                name: "LeaveApprovals",
                newName: "LeaveApproval");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_UserId",
                table: "LeaveRequest",
                newName: "IX_LeaveRequest_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveApprovals_ManagerId",
                table: "LeaveApproval",
                newName: "IX_LeaveApproval_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveApprovals_LeaveRequestId",
                table: "LeaveApproval",
                newName: "IX_LeaveApproval_LeaveRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest",
                column: "LeaveRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveApproval",
                table: "LeaveApproval",
                column: "LeaveApprovalId");

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApproval_AspNetUsers_ManagerId",
                table: "LeaveApproval",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApproval_LeaveRequest_LeaveRequestId",
                table: "LeaveApproval",
                column: "LeaveRequestId",
                principalTable: "LeaveRequest",
                principalColumn: "LeaveRequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_UserId",
                table: "LeaveRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApproval_AspNetUsers_ManagerId",
                table: "LeaveApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApproval_LeaveRequest_LeaveRequestId",
                table: "LeaveApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_UserId",
                table: "LeaveRequest");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveApproval",
                table: "LeaveApproval");

            migrationBuilder.RenameTable(
                name: "LeaveRequest",
                newName: "LeaveRequests");

            migrationBuilder.RenameTable(
                name: "LeaveApproval",
                newName: "LeaveApprovals");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequest_UserId",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveApproval_ManagerId",
                table: "LeaveApprovals",
                newName: "IX_LeaveApprovals_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveApproval_LeaveRequestId",
                table: "LeaveApprovals",
                newName: "IX_LeaveApprovals_LeaveRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests",
                column: "LeaveRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveApprovals",
                table: "LeaveApprovals",
                column: "LeaveApprovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApprovals_AspNetUsers_ManagerId",
                table: "LeaveApprovals",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApprovals_LeaveRequests_LeaveRequestId",
                table: "LeaveApprovals",
                column: "LeaveRequestId",
                principalTable: "LeaveRequests",
                principalColumn: "LeaveRequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_UserId",
                table: "LeaveRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
