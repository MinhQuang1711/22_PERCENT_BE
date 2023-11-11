using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22Percent_BE.Migrations
{
    public partial class update_detailSaleInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailSaleInvoices_Products_productId",
                table: "DetailSaleInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailSaleInvoices_SaleInvoices_saleInvoiceId",
                table: "DetailSaleInvoices");

            migrationBuilder.RenameColumn(
                name: "saleInvoiceId",
                table: "DetailSaleInvoices",
                newName: "SaleInvoiceId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "DetailSaleInvoices",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "DetailSaleInvoices",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailSaleInvoices_saleInvoiceId",
                table: "DetailSaleInvoices",
                newName: "IX_DetailSaleInvoices_SaleInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailSaleInvoices_productId",
                table: "DetailSaleInvoices",
                newName: "IX_DetailSaleInvoices_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "SaleInvoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "DetailSaleInvoices",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailSaleInvoices_Products_ProductId",
                table: "DetailSaleInvoices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailSaleInvoices_SaleInvoices_SaleInvoiceId",
                table: "DetailSaleInvoices",
                column: "SaleInvoiceId",
                principalTable: "SaleInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailSaleInvoices_Products_ProductId",
                table: "DetailSaleInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailSaleInvoices_SaleInvoices_SaleInvoiceId",
                table: "DetailSaleInvoices");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "DetailSaleInvoices");

            migrationBuilder.RenameColumn(
                name: "SaleInvoiceId",
                table: "DetailSaleInvoices",
                newName: "saleInvoiceId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "DetailSaleInvoices",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "DetailSaleInvoices",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailSaleInvoices_SaleInvoiceId",
                table: "DetailSaleInvoices",
                newName: "IX_DetailSaleInvoices_saleInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailSaleInvoices_ProductId",
                table: "DetailSaleInvoices",
                newName: "IX_DetailSaleInvoices_productId");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "SaleInvoices",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailSaleInvoices_Products_productId",
                table: "DetailSaleInvoices",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailSaleInvoices_SaleInvoices_saleInvoiceId",
                table: "DetailSaleInvoices",
                column: "saleInvoiceId",
                principalTable: "SaleInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
