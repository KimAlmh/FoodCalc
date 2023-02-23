using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodCalcApi.Migrations
{
    /// <inheritdoc />
    public partial class weight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "FoodPerPieces");
        }
    }
}
