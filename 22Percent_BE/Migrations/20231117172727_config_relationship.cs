using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22Percent_BE.Migrations
{
    public partial class config_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Users",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "SaleInvoices",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "PaymentInvoices",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Ingredients",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "ImportInvoices",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_CreateUser",
                table: "SaleInvoices",
                column: "CreateUser");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInvoices_CreateUser",
                table: "PaymentInvoices",
                column: "CreateUser");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_CreateUser",
                table: "Ingredients",
                column: "CreateUser");

            migrationBuilder.CreateIndex(
                name: "IX_ImportInvoices_CreateUser",
                table: "ImportInvoices",
                column: "CreateUser");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ImportInvoices_Users_CreateUser",
                table: "ImportInvoices",
                column: "CreateUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Users_CreateUser",
                table: "Ingredients",
                column: "CreateUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInvoices_Users_CreateUser",
                table: "PaymentInvoices",
                column: "CreateUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoices_Users_CreateUser",
                table: "SaleInvoices",
                column: "CreateUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_ImportInvoices_Users_CreateUser",
                table: "ImportInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Users_CreateUser",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInvoices_Users_CreateUser",
                table: "PaymentInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoices_Users_CreateUser",
                table: "SaleInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SaleInvoices_CreateUser",
                table: "SaleInvoices");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInvoices_CreateUser",
                table: "PaymentInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_CreateUser",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_ImportInvoices_CreateUser",
                table: "ImportInvoices");

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
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "SaleInvoices");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "PaymentInvoices");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "ImportInvoices");

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
    }
}
