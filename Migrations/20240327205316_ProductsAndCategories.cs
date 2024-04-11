using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Bread_Pit.Migrations
{
    public partial class ProductsAndCategories : Migration
    {
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
                    ProduktNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergieën = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extra = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "ProductID", "Allergieën", "CategorieCategoryID", "CategoryID", "Extra", "Omschrijving", "Prijs", "ProduktNaam" },
                values: new object[,]
                {
                    { 1, "Contacteer on hierover!", null, 1, "Geen extra info meer beschikbaar", "Soep", 1.1m, "Soep van de dag" },
                    { 2, "Gluten, Lactose, Soja, Selderij", null, 7, "Kan sporen van noten bevatten", "Stokbrood", 0.55m, "Stuk stokbrood" },
                    { 3, "Contacteer on hierover!", null, 7, "Geen extra info", "Boter", 0.55m, "Blokje melkerij boter" },
                    { 4, "Contacteer on hierover!", null, 2, "Geen extra info", "Ceasar Salad", 5m, "Sla met stukjes Kip" },
                    { 5, "Contacteer on hierover!", null, 3, "Geen extra info", "Pasta 4 Kazen", 5.5m, "Pasta Klein" },
                    { 6, "Contacteer ons hierover!", null, 3, "Geen extra info", "Pasta 4 kazen", 7m, "Pasta Groot" },
                    { 7, "Contacteer ons hierover!", null, 5, "Geen extra info", "Panini met ham en kaas", 4m, "Panini" },
                    { 8, "Contacteer ons hierover!", null, 5, "Geen extra info", "Belegd Broodje met kaas", 2.85m, "Kaas" },
                    { 9, "Contacteer ons hierover!", null, 5, "Geen extra info", "Belegd Broodje met ham", 2.85m, "Ham" },
                    { 10, "Contacteer ons hierover!", null, 5, "Geen extra info", "Belegd Broodje met kaas/ham", 3m, "Kaas/Ham" },
                    { 11, "Contacteer ons hierover!", null, 5, "Geen extra info", "Belegd Broodje met prepare", 3m, "Prepare" },
                    { 12, "Contacteer ons hierover!", null, 5, "Geen extra info", "Belegd Broodje met smos", 3.1m, "Smos" },
                    { 13, "Contacteer ons hierover!", null, 5, "Geen extra info", "Belegd Broodje met kip curry", 3.1m, "Kip curry" },
                    { 14, "Contacteer ons hierover!", null, 5, "Geen extra info", "Belegd Broodje met surimi", 3.5m, "Surimi" },
                    { 15, "Contacteer ons hierover!", null, 5, "Geen extra info", "Belegd Broodje met gerookte ham", 4m, "Gerookte ham" },
                    { 16, "Contacteer ons hierover!", null, 5, "Geen extra info", "Belegd Broodje met gerookte zalm", 4m, "Gerookte zalm" },
                    { 17, "Contacteer ons hierover!", null, 6, "Geen extra info", "Stukje fruit", 0.35m, "Stuk fruit" },
                    { 18, "Contacteer ons hierover!", null, 6, "Geen extra info", "Potje yogurt", 1.3m, "Yogurt" },
                    { 19, "Contacteer ons hierover!", null, 6, "Geen extra info", "Dessert", 2.2m, "Home-made dessert" },
                    { 20, "Contacteer ons hierover!", null, 6, "Geen extra info", "Foodbar", 2.75m, "Crazy Berry" },
                    { 21, "Contacteer ons hierover!", null, 6, "Geen extra info", "Foodbar", 2.75m, "Good Food" },
                    { 22, "Contacteer ons hierover!", null, 6, "Geen extra info", "Dessert", 1.45m, "Muffin / Donut" },
                    { 23, "Contacteer ons hierover!", null, 6, "Geen extra info", "Dessert", 1.65m, "Gebak" },
                    { 24, "Contacteer ons hierover!", null, 6, "Geen extra info", "Dessert", 1.3m, "Dessert voorverpakt" },
                    { 25, "Contacteer ons hierover!", null, 6, "Geen extra info", "Snoep", 1.3m, "Snoep" },
                    { 26, "Contacteer ons hierover!", null, 6, "Geen extra info", "Snoep", 1.45m, "Kinder Bueno" },
                    { 27, "Contacteer ons hierover!", null, 6, "Geen extra info", "Snoep", 1.65m, "Chips" },
                    { 28, "Contacteer ons hierover!", null, 6, "Geen extra info", "Snoep", 1.65m, "Chocolade" },
                    { 29, "Contacteer ons hierover!", null, 6, "Geen extra info", "Smoothie", 3.1m, "Innocent smoothie" },
                    { 30, "Contacteer ons hierover!", null, 8, "Geen extra info", "Chaudefontaine", 1.3m, "Plat water (0.5L)" },
                    { 31, "Contacteer ons hierover!", null, 8, "Geen extra info", "Chaudefontaine", 1.3m, "Bruis water (0.5L)" },
                    { 32, "Contacteer ons hierover!", null, 8, "Geen extra info", "Flesje frisdrank", 1.75m, "Cola (0.5L)" },
                    { 33, "Contacteer ons hierover!", null, 8, "Geen extra info", "Flesje frisdrank", 1.75m, "Fanta (0.5L)" },
                    { 34, "Contacteer ons hierover!", null, 8, "Geen extra info", "Flesje frisdrank", 1.75m, "Sprite (0.5L)" }
                });

            migrationBuilder.InsertData(
                table: "Produkten",
                columns: new[] { "ProductID", "Allergieën", "CategorieCategoryID", "CategoryID", "Extra", "Omschrijving", "Prijs", "ProduktNaam" },
                values: new object[,]
                {
                    { 35, "Contacteer ons hierover!", null, 8, "Geen extra info", "Flesje frisdrank", 1.9m, "Lipton Ice-Tea (0.5L)" },
                    { 36, "Contacteer ons hierover!", null, 8, "Geen extra info", "Flesje fruitsap", 1.75m, "Appelsiensap (0.33L)" },
                    { 37, "Contacteer ons hierover!", null, 8, "Geen extra info", "Flesje fruitsap", 1.75m, "Appelsap (0.33L)" },
                    { 38, "Contacteer ons hierover!", null, 8, "Geen extra info", "Flesje Cécémel", 1.75m, "Cécémel (0.33L)" },
                    { 39, "Contacteer ons hierover!", null, 8, "Geen extra info", "Energiedrank", 2.2m, "Blikje Nalu (0.25L)" },
                    { 40, "Contacteer ons hierover!", null, 8, "Geen extra info", "Energiedrank", 2.75m, "Red-Bull (0.25L)" },
                    { 41, "Contacteer ons hierover!", null, 8, "Geen extra info", "Koffiedrank", 1.2m, "Cold Coffee to Go" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkten_CategorieCategoryID",
                table: "Produkten",
                column: "CategorieCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkten");

            migrationBuilder.DropTable(
                name: "Categorien");
        }
    }
}
