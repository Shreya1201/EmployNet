using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLeaveRequestAndApprovalRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LeaveRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "LeaveApprovals",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_UserId",
                table: "LeaveRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_LeaveRequestId",
                table: "LeaveApprovals",
                column: "LeaveRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_ManagerId",
                table: "LeaveApprovals",
                column: "ManagerId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequests_UserId",
                table: "LeaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApprovals_LeaveRequestId",
                table: "LeaveApprovals");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApprovals_ManagerId",
                table: "LeaveApprovals");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "LeaveApprovals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
