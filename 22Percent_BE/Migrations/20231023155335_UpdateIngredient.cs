using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22Percent_BE.Migrations
{
    public partial class UpdateIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "realWeight",
                table: "Ingredients",
                newName: "RealWeight");

            migrationBuilder.RenameColumn(
                name: "netWeight",
                table: "Ingredients",
                newName: "NetWeight");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Ingredients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "loss",
                table: "Ingredients",
                newName: "Loss");

            migrationBuilder.RenameColumn(
                name: "importPrice",
                table: "Ingredients",
                newName: "ImportPrice");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Ingredients",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "RealWeight",
                table: "Ingredients",
                newName: "realWeight");

            migrationBuilder.RenameColumn(
                name: "NetWeight",
                table: "Ingredients",
                newName: "netWeight");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Ingredients",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Loss",
                table: "Ingredients",
                newName: "loss");

            migrationBuilder.RenameColumn(
                name: "ImportPrice",
                table: "Ingredients",
                newName: "importPrice");
        }
    }
}
