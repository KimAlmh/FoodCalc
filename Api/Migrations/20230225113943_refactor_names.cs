using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class refactor_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SearchNames_FoodPerGrams_FoodPerGramId",
                table: "SearchNames");

            migrationBuilder.DropTable(
                name: "FoodPerPieces");

            migrationBuilder.DropTable(
                name: "FoodPerGrams");

            migrationBuilder.RenameColumn(
                name: "FoodPerGramId",
                table: "SearchNames",
                newName: "FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_SearchNames_Name_FoodPerGramId",
                table: "SearchNames",
                newName: "IX_SearchNames_Name_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_SearchNames_FoodPerGramId",
                table: "SearchNames",
                newName: "IX_SearchNames_FoodId");

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Kcal = table.Column<double>(type: "float", nullable: false),
                    Kj = table.Column<double>(type: "float", nullable: false),
                    Carbohydrate = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Sugar = table.Column<double>(type: "float", nullable: false),
                    Fibre = table.Column<double>(type: "float", nullable: false),
                    SaturatedFat = table.Column<double>(type: "float", nullable: false),
                    Salt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pieces_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_BrandId",
                table: "Food",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Name_BrandId",
                table: "Food",
                columns: new[] { "Name", "BrandId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_FoodId",
                table: "Pieces",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_Weight_FoodId",
                table: "Pieces",
                columns: new[] { "Weight", "FoodId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchNames_Food_FoodId",
                table: "SearchNames",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SearchNames_Food_FoodId",
                table: "SearchNames");

            migrationBuilder.DropTable(
                name: "Pieces");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "SearchNames",
                newName: "FoodPerGramId");

            migrationBuilder.RenameIndex(
                name: "IX_SearchNames_Name_FoodId",
                table: "SearchNames",
                newName: "IX_SearchNames_Name_FoodPerGramId");

            migrationBuilder.RenameIndex(
                name: "IX_SearchNames_FoodId",
                table: "SearchNames",
                newName: "IX_SearchNames_FoodPerGramId");

            migrationBuilder.CreateTable(
                name: "FoodPerGrams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Carbohydrate = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Fibre = table.Column<double>(type: "float", nullable: false),
                    Kcal = table.Column<double>(type: "float", nullable: false),
                    Kj = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Salt = table.Column<double>(type: "float", nullable: false),
                    SaturatedFat = table.Column<double>(type: "float", nullable: false),
                    Sugar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPerGrams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPerGrams_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodPerPieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodPerGramId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPerPieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPerPieces_FoodPerGrams_FoodPerGramId",
                        column: x => x.FoodPerGramId,
                        principalTable: "FoodPerGrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodPerGrams_BrandId",
                table: "FoodPerGrams",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPerPieces_FoodPerGramId",
                table: "FoodPerPieces",
                column: "FoodPerGramId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPerPieces_Weight_FoodPerGramId",
                table: "FoodPerPieces",
                columns: new[] { "Weight", "FoodPerGramId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchNames_FoodPerGrams_FoodPerGramId",
                table: "SearchNames",
                column: "FoodPerGramId",
                principalTable: "FoodPerGrams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
