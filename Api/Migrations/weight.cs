#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodCalcApi.Migrations;

/// <inheritdoc />
public partial class weight : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<double>(
            "Weight",
            "FoodPerPieces",
            "float",
            nullable: false,
            defaultValue: 0.0);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "Weight",
            "FoodPerPieces");
    }
}