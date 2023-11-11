using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22Percent_BE.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailImportInvoices_ImportInvoices_importInvoiceId",
                table: "DetailImportInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailImportInvoices_Ingredients_ingredientId",
                table: "DetailImportInvoices");

            migrationBuilder.DropColumn(
                name: "createUser",
                table: "SaleInvoices");

            migrationBuilder.DropColumn(
                name: "createUser",
                table: "PaymentInvoices");

            migrationBuilder.DropColumn(
                name: "createUser",
                table: "ImportInvoices");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "SaleInvoices",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "SaleInvoices",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "SaleInvoices",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "SaleInvoices",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "PaymentInvoices",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "descriptions",
                table: "PaymentInvoices",
                newName: "Descriptions");

            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "PaymentInvoices",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "ImportInvoices",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "ImportInvoices",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "DetailImportInvoices",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "DetailImportInvoices",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ingredientId",
                table: "DetailImportInvoices",
                newName: "IngredientId");

            migrationBuilder.RenameColumn(
                name: "importInvoiceId",
                table: "DetailImportInvoices",
                newName: "ImportInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailImportInvoices_ingredientId",
                table: "DetailImportInvoices",
                newName: "IX_DetailImportInvoices_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailImportInvoices_importInvoiceId",
                table: "DetailImportInvoices",
                newName: "IX_DetailImportInvoices_ImportInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailImportInvoices_ImportInvoices_ImportInvoiceId",
                table: "DetailImportInvoices",
                column: "ImportInvoiceId",
                principalTable: "ImportInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailImportInvoices_Ingredients_IngredientId",
                table: "DetailImportInvoices",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailImportInvoices_ImportInvoices_ImportInvoiceId",
                table: "DetailImportInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailImportInvoices_Ingredients_IngredientId",
                table: "DetailImportInvoices");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "SaleInvoices",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "SaleInvoices",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "SaleInvoices",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "SaleInvoices",
                newName: "createDate");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "PaymentInvoices",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Descriptions",
                table: "PaymentInvoices",
                newName: "descriptions");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "PaymentInvoices",
                newName: "createDate");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "ImportInvoices",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ImportInvoices",
                newName: "createDate");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "DetailImportInvoices",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "DetailImportInvoices",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "DetailImportInvoices",
                newName: "ingredientId");

            migrationBuilder.RenameColumn(
                name: "ImportInvoiceId",
                table: "DetailImportInvoices",
                newName: "importInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailImportInvoices_IngredientId",
                table: "DetailImportInvoices",
                newName: "IX_DetailImportInvoices_ingredientId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailImportInvoices_ImportInvoiceId",
                table: "DetailImportInvoices",
                newName: "IX_DetailImportInvoices_importInvoiceId");

            migrationBuilder.AddColumn<string>(
                name: "createUser",
                table: "SaleInvoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "createUser",
                table: "PaymentInvoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "createUser",
                table: "ImportInvoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailImportInvoices_ImportInvoices_importInvoiceId",
                table: "DetailImportInvoices",
                column: "importInvoiceId",
                principalTable: "ImportInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailImportInvoices_Ingredients_ingredientId",
                table: "DetailImportInvoices",
                column: "ingredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
