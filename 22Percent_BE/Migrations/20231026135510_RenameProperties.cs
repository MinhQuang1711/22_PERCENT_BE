using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22Percent_BE.Migrations
{
    public partial class RenameProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SaleInvoices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PaymentInvoices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Ingredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ImportInvoices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DetailSaleInvoices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DetailProducts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DetailImportInvoices",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "IngredientName",
                table: "DetailProducts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientName",
                table: "DetailProducts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SaleInvoices",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaymentInvoices",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ingredients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ImportInvoices",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetailSaleInvoices",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetailProducts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetailImportInvoices",
                newName: "id");
        }
    }
}
