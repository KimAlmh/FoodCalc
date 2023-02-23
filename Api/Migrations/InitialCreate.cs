#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodCalcApi.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Brands",
            table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(max)", nullable: true),
                Description = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Brands", x => x.Id); });

        migrationBuilder.CreateTable(
            "FoodPerGrams",
            table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(max)", nullable: true),
                BrandId = table.Column<int>("int", nullable: true),
                Kcal = table.Column<double>("float", nullable: false),
                Kj = table.Column<double>("float", nullable: false),
                Carbohydrate = table.Column<double>("float", nullable: false),
                Fat = table.Column<double>("float", nullable: false),
                Protein = table.Column<double>("float", nullable: false),
                Sugar = table.Column<double>("float", nullable: false),
                Fibre = table.Column<double>("float", nullable: false),
                SaturatedFat = table.Column<double>("float", nullable: false),
                Salt = table.Column<double>("float", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FoodPerGrams", x => x.Id);
                table.ForeignKey(
                    "FK_FoodPerGrams_Brands_BrandId",
                    x => x.BrandId,
                    "Brands",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "FoodPerPieces",
            table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(max)", nullable: true),
                BrandId = table.Column<int>("int", nullable: true),
                Kcal = table.Column<double>("float", nullable: false),
                Kj = table.Column<double>("float", nullable: false),
                Carbohydrate = table.Column<double>("float", nullable: false),
                Fat = table.Column<double>("float", nullable: false),
                Protein = table.Column<double>("float", nullable: false),
                Sugar = table.Column<double>("float", nullable: false),
                Fibre = table.Column<double>("float", nullable: false),
                SaturatedFat = table.Column<double>("float", nullable: false),
                Salt = table.Column<double>("float", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FoodPerPieces", x => x.Id);
                table.ForeignKey(
                    "FK_FoodPerPieces_Brands_BrandId",
                    x => x.BrandId,
                    "Brands",
                    "Id");
            });

        migrationBuilder.CreateIndex(
            "IX_FoodPerGrams_BrandId",
            "FoodPerGrams",
            "BrandId");

        migrationBuilder.CreateIndex(
            "IX_FoodPerPieces_BrandId",
            "FoodPerPieces",
            "BrandId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "FoodPerGrams");

        migrationBuilder.DropTable(
            "FoodPerPieces");

        migrationBuilder.DropTable(
            "Brands");
    }
}