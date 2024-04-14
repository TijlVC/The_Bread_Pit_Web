using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Bread_Pit.Data.Migrations
{
    public partial class UpdateProduktenImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Produkten",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bestellingen",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "ImagePath", "Omschrijving" },
                values: new object[] { "soep.jpeg", "Soep van de dag (zie bord)" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "ImagePath", "Omschrijving" },
                values: new object[] { "stokbrood.jpeg", "Stuk stokbrood (20cm)" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "ImagePath",
                value: "Boter.jpeg");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "ImagePath",
                value: "CeasarSalad.jpeg");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 5,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "PastaKlein.jpeg", "Pasta 4 kazen klein", "Pasta Klein" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 6,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "PastaGroot.jpeg", "Pasta 4 kazen Groot", "Pasta Groot" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "ImagePath",
                value: "Panini.jpeg");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 8,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "BroodjeKaas.jpg", "Belegd Broodje met kaas", "Broodje Kaas" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 9,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "BroodjeHam.jpeg", "Belegd broodje metham", "Broodje Ham" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 10,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "BroodjeKaas-Ham.jpeg", "Belegd Broodje met kaas/ham", "Broodje Kaas - Ham" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 11,
                column: "ImagePath",
                value: "BroodjePrepare.jpeg");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 12,
                columns: new[] { "ImagePath", "Omschrijving" },
                values: new object[] { "Smoske.jpeg", "Smoske" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 13,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "BroodjeKipCurry.jpeg", "Belegd Broodje met kip curry", "Broodje Kip Curry" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 14,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "BroodjeSurimi.jpeg", "Belegd Broodje met surimi", "Broodje Surimi" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 15,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "BroodjeGerookteHam.jpeg", "Belegd Broodje met gerookte ham", "Broodje Gerookte Ham" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 16,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "BroodjeGerookteZalm.jpeg", "Belegd Broodje met gerookte zalm", "Broodje Gerookte Zalm" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 17,
                columns: new[] { "ImagePath", "Omschrijving" },
                values: new object[] { "StukjeFruit.jpeg", "Stuk fruit (Appel, Peer, Banaan, 2x kiwi)" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 18,
                columns: new[] { "ImagePath", "Omschrijving" },
                values: new object[] { "PotjeYogurt.jpeg", "Potje yogurt" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 19,
                column: "ImagePath",
                value: "HomeMadeDessert.jpeg");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 20,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "FoodbaryBerry.jpeg", "Foodbar - Crazy Berry", "Foodbar Berry" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 21,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "FoodbarHealt.jpeg", "Foodbar - Good Food", "Foodbar Healt" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 22,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "Muffin-Donut.jpeg", "Muffin of Donut", "Muffin - Donut" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 23,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "Gebak.jpeg", "Stukje gebak (zelf gebakken)", "Gebak" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 24,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "DessertVoorverpaktDessert.jpeg", "Dessert in voorverpakking", "Voorverpakt Dessert" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 25,
                columns: new[] { "ImagePath", "Omschrijving" },
                values: new object[] { "Snoep.jpeg", "Zakje Snoep" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 26,
                columns: new[] { "ImagePath", "ProduktNaam" },
                values: new object[] { "KinderBueno.jpeg", "Kinder Bueno" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 27,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "Chips.jpeg", "Zakje Chips", "Chips" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 28,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "Chocolade.jpeg", "Reep Chocolade", "Chocolade" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 29,
                column: "ImagePath",
                value: "Smoothie.jpeg");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 30,
                column: "ImagePath",
                value: "Chaudefontaine.jpeg");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 31,
                column: "ImagePath",
                value: "Chaudefontaine.jpeg");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 32,
                columns: new[] { "ImagePath", "ProduktNaam" },
                values: new object[] { "Cola.jpeg", "Cola" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 33,
                columns: new[] { "ImagePath", "ProduktNaam" },
                values: new object[] { "Fanta.jpeg", "Fanta" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 34,
                columns: new[] { "ImagePath", "ProduktNaam" },
                values: new object[] { "Sprite.jpeg", "Sprite" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 35,
                columns: new[] { "ImagePath", "ProduktNaam" },
                values: new object[] { "LiptonIce-Tea.jpeg", "Lipton Ice-Tea" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 36,
                columns: new[] { "ImagePath", "ProduktNaam" },
                values: new object[] { "Appelsiensap.jpeg", "Appelsiensap" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 37,
                columns: new[] { "ImagePath", "ProduktNaam" },
                values: new object[] { "Appelsap.jpeg", "Appelsap" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 38,
                columns: new[] { "ImagePath", "ProduktNaam" },
                values: new object[] { "Cécémel.jpeg", "Cécémel" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 39,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "BlikjeNalu.jpeg", "Nalu (0.25L)", "Blikje Nalu" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 40,
                columns: new[] { "ImagePath", "ProduktNaam" },
                values: new object[] { "Red-Bull.jpeg", "Blikje Red-Bull" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 41,
                columns: new[] { "ImagePath", "Omschrijving", "ProduktNaam" },
                values: new object[] { "ColdCoffeeToGo.jpeg", "Cup koude kofie om mee te nemen", "Cold Coffee to Go" });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_UserId",
                table: "Bestellingen",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellingen_AspNetUsers_UserId",
                table: "Bestellingen",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellingen_AspNetUsers_UserId",
                table: "Bestellingen");

            migrationBuilder.DropIndex(
                name: "IX_Bestellingen_UserId",
                table: "Bestellingen");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Produkten");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bestellingen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "Omschrijving",
                value: "Soep van de dag");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "Omschrijving",
                value: "Stuk stokbrood");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 5,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Pasta Klein", "Pasta 4 Kazen" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 6,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Pasta Groot", "Pasta 4 kazen" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 8,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Kaas", "Belegd Broodje met kaas" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 9,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Ham", "Belegd Broodje met ham" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 10,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Kaas/Ham", "Belegd Broodje met kaas/ham" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 12,
                column: "Omschrijving",
                value: "Smos");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 13,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Kip curry", "Belegd Broodje met kip curry" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 14,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Surimi", "Belegd Broodje met surimi" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 15,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Gerookte ham", "Belegd Broodje met gerookte ham" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 16,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Gerookte zalm", "Belegd Broodje met gerookte zalm" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 17,
                column: "Omschrijving",
                value: "Stuk fruit");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 18,
                column: "Omschrijving",
                value: "Yogurt");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 20,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Crazy Berry", "Foodbar" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 21,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Good Food", "Foodbar" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 22,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Muffin / Donut", "Dessert" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 23,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Gebak", "Dessert" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 24,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Dessert voorverpakt", "Dessert" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 25,
                column: "Omschrijving",
                value: "Snoep");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 26,
                column: "ProduktNaam",
                value: "Snoep");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 27,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Chips", "Snoep" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 28,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Chocolade", "Snoep" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 32,
                column: "ProduktNaam",
                value: "Flesje frisdrank");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 33,
                column: "ProduktNaam",
                value: "Flesje frisdrank");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 34,
                column: "ProduktNaam",
                value: "Flesje frisdrank");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 35,
                column: "ProduktNaam",
                value: "Flesje frisdrank");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 36,
                column: "ProduktNaam",
                value: "Flesje fruitsap");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 37,
                column: "ProduktNaam",
                value: "Flesje fruitsap");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 38,
                column: "ProduktNaam",
                value: "Flesje Cécémel");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 39,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Blikje Nalu (0.25L)", "Energiedrank" });

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 40,
                column: "ProduktNaam",
                value: "Energiedrank");

            migrationBuilder.UpdateData(
                table: "Produkten",
                keyColumn: "ProductID",
                keyValue: 41,
                columns: new[] { "Omschrijving", "ProduktNaam" },
                values: new object[] { "Cold Coffee to Go", "Koffiedrank" });
        }
    }
}
