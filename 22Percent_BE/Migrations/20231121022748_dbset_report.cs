using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22Percent_BE.Migrations
{
    public partial class dbset_report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Users_CreateUser",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "Reports");

            migrationBuilder.RenameIndex(
                name: "IX_Report_CreateUser",
                table: "Reports",
                newName: "IX_Reports_CreateUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_CreateUser",
                table: "Reports",
                column: "CreateUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_CreateUser",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Report");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_CreateUser",
                table: "Report",
                newName: "IX_Report_CreateUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Users_CreateUser",
                table: "Report",
                column: "CreateUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
