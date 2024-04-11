using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Bread_Pit.Data.Migrations
{
    public partial class AddBestelItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellingen_AspNetUsers_UserId",
                table: "Bestellingen");

            migrationBuilder.DropIndex(
                name: "IX_Bestellingen_UserId",
                table: "Bestellingen");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bestellingen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "BestelItems",
                columns: table => new
                {
                    BestelItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aantal = table.Column<int>(type: "int", nullable: false),
                    PrijsPerStuk = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProduktProductID = table.Column<int>(type: "int", nullable: false),
                    BestellingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestelItems", x => x.BestelItemId);
                    table.ForeignKey(
                        name: "FK_BestelItems_Bestellingen_BestellingId",
                        column: x => x.BestellingId,
                        principalTable: "Bestellingen",
                        principalColumn: "BestellingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestelItems_Produkten_ProduktProductID",
                        column: x => x.ProduktProductID,
                        principalTable: "Produkten",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BestelItems_BestellingId",
                table: "BestelItems",
                column: "BestellingId");

            migrationBuilder.CreateIndex(
                name: "IX_BestelItems_ProduktProductID",
                table: "BestelItems",
                column: "ProduktProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestelItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bestellingen",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
