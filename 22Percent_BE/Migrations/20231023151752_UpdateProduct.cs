using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22Percent_BE.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailProducts_Ingredients_ingredientID",
                table: "DetailProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailProducts_Products_productId",
                table: "DetailProducts");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "createUser",
                table: "Products",
                newName: "CreateUser");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "Products",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "DetailProducts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ingredientID",
                table: "DetailProducts",
                newName: "IngredientID");

            migrationBuilder.RenameIndex(
                name: "IX_DetailProducts_productId",
                table: "DetailProducts",
                newName: "IX_DetailProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailProducts_ingredientID",
                table: "DetailProducts",
                newName: "IX_DetailProducts_IngredientID");

            migrationBuilder.AddColumn<double>(
                name: "Profit",
                table: "Products",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "DetailProducts",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "DetailProducts",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailProducts_Ingredients_IngredientID",
                table: "DetailProducts",
                column: "IngredientID",
                principalTable: "Ingredients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailProducts_Products_ProductId",
                table: "DetailProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailProducts_Ingredients_IngredientID",
                table: "DetailProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailProducts_Products_ProductId",
                table: "DetailProducts");

            migrationBuilder.DropColumn(
                name: "Profit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "DetailProducts");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "DetailProducts");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreateUser",
                table: "Products",
                newName: "createUser");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Products",
                newName: "cost");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "DetailProducts",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "IngredientID",
                table: "DetailProducts",
                newName: "ingredientID");

            migrationBuilder.RenameIndex(
                name: "IX_DetailProducts_ProductId",
                table: "DetailProducts",
                newName: "IX_DetailProducts_productId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailProducts_IngredientID",
                table: "DetailProducts",
                newName: "IX_DetailProducts_ingredientID");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailProducts_Ingredients_ingredientID",
                table: "DetailProducts",
                column: "ingredientID",
                principalTable: "Ingredients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailProducts_Products_productId",
                table: "DetailProducts",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
