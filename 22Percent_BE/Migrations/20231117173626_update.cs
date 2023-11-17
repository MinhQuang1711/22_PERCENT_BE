using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22Percent_BE.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailImportInvoices_Users_UserId",
                table: "DetailImportInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailProducts_Users_UserId",
                table: "DetailProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailSaleInvoices_Users_UserId",
                table: "DetailSaleInvoices");

            migrationBuilder.DropIndex(
                name: "IX_DetailSaleInvoices_UserId",
                table: "DetailSaleInvoices");

            migrationBuilder.DropIndex(
                name: "IX_DetailProducts_UserId",
                table: "DetailProducts");

            migrationBuilder.DropIndex(
                name: "IX_DetailImportInvoices_UserId",
                table: "DetailImportInvoices");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "DetailSaleInvoices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DetailSaleInvoices");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "DetailProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DetailProducts");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "DetailImportInvoices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DetailImportInvoices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "DetailSaleInvoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DetailSaleInvoices",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "DetailProducts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DetailProducts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "DetailImportInvoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DetailImportInvoices",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DetailSaleInvoices_UserId",
                table: "DetailSaleInvoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailProducts_UserId",
                table: "DetailProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailImportInvoices_UserId",
                table: "DetailImportInvoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailImportInvoices_Users_UserId",
                table: "DetailImportInvoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailProducts_Users_UserId",
                table: "DetailProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailSaleInvoices_Users_UserId",
                table: "DetailSaleInvoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
