using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22Percent_BE.Migrations
{
    public partial class refrence_to_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailIngredient_Ingredients_IngredientId",
                table: "DetailIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailIngredient",
                table: "DetailIngredient");

            migrationBuilder.RenameTable(
                name: "DetailIngredient",
                newName: "DetailIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_DetailIngredient_IngredientId",
                table: "DetailIngredients",
                newName: "IX_DetailIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailIngredients",
                table: "DetailIngredients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailIngredients_Ingredients_IngredientId",
                table: "DetailIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailIngredients_Ingredients_IngredientId",
                table: "DetailIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailIngredients",
                table: "DetailIngredients");

            migrationBuilder.RenameTable(
                name: "DetailIngredients",
                newName: "DetailIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_DetailIngredients_IngredientId",
                table: "DetailIngredient",
                newName: "IX_DetailIngredient_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailIngredient",
                table: "DetailIngredient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailIngredient_Ingredients_IngredientId",
                table: "DetailIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
