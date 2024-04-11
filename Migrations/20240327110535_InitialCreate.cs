using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Bread_Pit.Migrations
{
    public partial class InitialCreate : Migration
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

            migrationBuilder.CreateTable(
                name: "WinkelmandjeItems",
                columns: table => new
                {
                    WinkelmandjeItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktProductID = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false),
                    SessieId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinkelmandjeItems", x => x.WinkelmandjeItemID);
                    table.ForeignKey(
                        name: "FK_WinkelmandjeItems_Produkten_ProduktProductID",
                        column: x => x.ProduktProductID,
                        principalTable: "Produkten",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, "Contacteer on hierover!", null, 1, "Geen extra info meer beschikbaar", "Soep van de dag", 1.1m, "Soep" },
                    { 2, "Gluten, Lactose, Soja, Selderij", null, 7, "Kan sporen van noten bevatten", "Stuk stokbrood", 0.55m, "Stokbrood" },
                    { 3, "Contacteer on hierover!", null, 7, "Geen extra info", "Blokje melkerij boter", 0.55m, "Boter" },
                    { 4, "Contacteer on hierover!", null, 2, "Geen extra info", "Sla met stukjes Kip", 5m, "Ceasar Salad" },
                    { 5, "Contacteer on hierover!", null, 3, "Geen extra info", "Pasta Klein", 5.5m, "Pasta 4 Kazen" },
                    { 6, "Contacteer ons hierover!", null, 3, "Geen extra info", "Pasta Groot", 7m, "Pasta 4 kazen" },
                    { 7, "Contacteer ons hierover!", null, 5, "Geen extra info", "Panini", 4m, "Panini met ham en kaas" },
                    { 8, "Contacteer ons hierover!", null, 5, "Geen extra info", "Kaas", 2.85m, "Belegd Broodje met kaas" },
                    { 9, "Contacteer ons hierover!", null, 5, "Geen extra info", "Ham", 2.85m, "Belegd Broodje met ham" },
                    { 10, "Contacteer ons hierover!", null, 5, "Geen extra info", "Kaas/Ham", 3m, "Belegd Broodje met kaas/ham" },
                    { 11, "Contacteer ons hierover!", null, 5, "Geen extra info", "Prepare", 3m, "Belegd Broodje met prepare" },
                    { 12, "Contacteer ons hierover!", null, 5, "Geen extra info", "Smos", 3.1m, "Belegd Broodje met smos" },
                    { 13, "Contacteer ons hierover!", null, 5, "Geen extra info", "Kip curry", 3.1m, "Belegd Broodje met kip curry" },
                    { 14, "Contacteer ons hierover!", null, 5, "Geen extra info", "Surimi", 3.5m, "Belegd Broodje met surimi" },
                    { 15, "Contacteer ons hierover!", null, 5, "Geen extra info", "Gerookte ham", 4m, "Belegd Broodje met gerookte ham" },
                    { 16, "Contacteer ons hierover!", null, 5, "Geen extra info", "Gerookte zalm", 4m, "Belegd Broodje met gerookte zalm" },
                    { 17, "Contacteer ons hierover!", null, 6, "Geen extra info", "Stuk fruit", 0.35m, "Stukje fruit" },
                    { 18, "Contacteer ons hierover!", null, 6, "Geen extra info", "Yogurt", 1.3m, "Potje yogurt" },
                    { 19, "Contacteer ons hierover!", null, 6, "Geen extra info", "Home-made dessert", 2.2m, "Dessert" },
                    { 20, "Contacteer ons hierover!", null, 6, "Geen extra info", "Crazy Berry", 2.75m, "Foodbar" },
                    { 21, "Contacteer ons hierover!", null, 6, "Geen extra info", "Good Food", 2.75m, "Foodbar" },
                    { 22, "Contacteer ons hierover!", null, 6, "Geen extra info", "Muffin / Donut", 1.45m, "Dessert" },
                    { 23, "Contacteer ons hierover!", null, 6, "Geen extra info", "Gebak", 1.65m, "Dessert" },
                    { 24, "Contacteer ons hierover!", null, 6, "Geen extra info", "Dessert voorverpakt", 1.3m, "Dessert" },
                    { 25, "Contacteer ons hierover!", null, 6, "Geen extra info", "Snoep", 1.3m, "Snoep" },
                    { 26, "Contacteer ons hierover!", null, 6, "Geen extra info", "Kinder Bueno", 1.45m, "Snoep" },
                    { 27, "Contacteer ons hierover!", null, 6, "Geen extra info", "Chips", 1.65m, "Snoep" },
                    { 28, "Contacteer ons hierover!", null, 6, "Geen extra info", "Chocolade", 1.65m, "Snoep" },
                    { 29, "Contacteer ons hierover!", null, 6, "Geen extra info", "Innocent smoothie", 3.1m, "Smoothie" },
                    { 30, "Contacteer ons hierover!", null, 8, "Geen extra info", "Plat water (0.5L)", 1.3m, "Chaudefontaine" },
                    { 31, "Contacteer ons hierover!", null, 8, "Geen extra info", "Bruis water (0.5L)", 1.3m, "Chaudefontaine" },
                    { 32, "Contacteer ons hierover!", null, 8, "Geen extra info", "Cola (0.5L)", 1.75m, "Flesje frisdrank" },
                    { 33, "Contacteer ons hierover!", null, 8, "Geen extra info", "Fanta (0.5L)", 1.75m, "Flesje frisdrank" },
                    { 34, "Contacteer ons hierover!", null, 8, "Geen extra info", "Sprite (0.5L)", 1.75m, "Flesje frisdrank" }
                });

            migrationBuilder.InsertData(
                table: "Produkten",
                columns: new[] { "ProductID", "Allergieën", "CategorieCategoryID", "CategoryID", "Extra", "Omschrijving", "Prijs", "ProduktNaam" },
                values: new object[,]
                {
                    { 35, "Contacteer ons hierover!", null, 8, "Geen extra info", "Lipton Ice-Tea (0.5L)", 1.9m, "Flesje frisdrank" },
                    { 36, "Contacteer ons hierover!", null, 8, "Geen extra info", "Appelsiensap (0.33L)", 1.75m, "Flesje fruitsap" },
                    { 37, "Contacteer ons hierover!", null, 8, "Geen extra info", "Appelsap (0.33L)", 1.75m, "Flesje fruitsap" },
                    { 38, "Contacteer ons hierover!", null, 8, "Geen extra info", "Cécémel (0.33L)", 1.75m, "Flesje Cécémel" },
                    { 39, "Contacteer ons hierover!", null, 8, "Geen extra info", "Blikje Nalu (0.25L)", 2.2m, "Energiedrank" },
                    { 40, "Contacteer ons hierover!", null, 8, "Geen extra info", "Red-Bull (0.25L)", 2.75m, "Energiedrank" },
                    { 41, "Contacteer ons hierover!", null, 8, "Geen extra info", "Cold Coffee to Go", 1.2m, "Koffiedrank" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkten_CategorieCategoryID",
                table: "Produkten",
                column: "CategorieCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_WinkelmandjeItems_ProduktProductID",
                table: "WinkelmandjeItems",
                column: "ProduktProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WinkelmandjeItems");

            migrationBuilder.DropTable(
                name: "Produkten");

            migrationBuilder.DropTable(
                name: "Categorien");
        }
    }
}
