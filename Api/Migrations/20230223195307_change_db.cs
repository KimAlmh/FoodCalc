using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class change_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPerGrams_Brands_BrandId",
                table: "FoodPerGrams");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPerPieces_Brands_BrandId",
                table: "FoodPerPieces");

            migrationBuilder.DropIndex(
                name: "IX_FoodPerPieces_BrandId",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "Carbohydrate",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "Fibre",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "Kcal",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "Kj",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "SaturatedFat",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "Sugar",
                table: "FoodPerPieces");

            migrationBuilder.AddColumn<int>(
                name: "FoodPerGramId",
                table: "FoodPerPieces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FoodPerGrams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "FoodPerGrams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SearchNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodPerGramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchNames_FoodPerGrams_FoodPerGramId",
                        column: x => x.FoodPerGramId,
                        principalTable: "FoodPerGrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodPerPieces_FoodPerGramId",
                table: "FoodPerPieces",
                column: "FoodPerGramId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchNames_FoodPerGramId",
                table: "SearchNames",
                column: "FoodPerGramId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPerGrams_Brands_BrandId",
                table: "FoodPerGrams",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPerPieces_FoodPerGrams_FoodPerGramId",
                table: "FoodPerPieces",
                column: "FoodPerGramId",
                principalTable: "FoodPerGrams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPerGrams_Brands_BrandId",
                table: "FoodPerGrams");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPerPieces_FoodPerGrams_FoodPerGramId",
                table: "FoodPerPieces");

            migrationBuilder.DropTable(
                name: "SearchNames");

            migrationBuilder.DropIndex(
                name: "IX_FoodPerPieces_FoodPerGramId",
                table: "FoodPerPieces");

            migrationBuilder.DropColumn(
                name: "FoodPerGramId",
                table: "FoodPerPieces");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "FoodPerPieces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Carbohydrate",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fibre",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Kcal",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Kj",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FoodPerPieces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Salt",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SaturatedFat",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Sugar",
                table: "FoodPerPieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FoodPerGrams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "FoodPerGrams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPerPieces_BrandId",
                table: "FoodPerPieces",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPerGrams_Brands_BrandId",
                table: "FoodPerGrams",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPerPieces_Brands_BrandId",
                table: "FoodPerPieces",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
