using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace The_Bread_Pit.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorien",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieNaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorien", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Produkten",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CategorieCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkten", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Produkten_Categorien_CategorieCategoryID",
                        column: x => x.CategorieCategoryID,
                        principalTable: "Categorien",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.InsertData(
                table: "Categorien",
                columns: new[] { "CategoryID", "CategorieNaam" },
                values: new object[,]
                {
                    { 1, "Soep" },
                    { 2, "Salades" },
                    { 3, "Pasta" },
                    { 4, "Snack" },
                    { 5, "Belegde broodjes" },
                    { 6, "Zoet / Fruit" },
                    { 7, "Andere" },
                    { 8, "Dranken" }
                });

            migrationBuilder.InsertData(
                table: "Produkten",
                columns: new[] { "ProductID", "CategorieCategoryID", "CategoryID", "Omschrijving", "Prijs", "ProductNaam" },
                values: new object[,]
                {
                    { 1, null, 1, "Soep van de dag", 1.1m, "Soep" },
                    { 2, null, 1, "Stuk stokbrood", 0.55m, "Stokbrood" },
                    { 3, null, 1, "Blokje melkerij boter", 0.55m, "Boter" },
                    { 4, null, 1, "Sla met stukjes Kip", 5m, "Ceasar Salad" },
                    { 5, null, 1, "Pasta Klein", 5.5m, "Pasta 4 Kazen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkten_CategorieCategoryID",
                table: "Produkten",
                column: "CategorieCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkten");

            migrationBuilder.DropTable(
                name: "Categorien");
        }
    }
}
