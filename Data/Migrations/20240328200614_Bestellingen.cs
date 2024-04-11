using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Bread_Pit.Data.Migrations
{
    public partial class Bestellingen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestellingId",
                table: "WinkelmandjeItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bestellingen",
                columns: table => new
                {
                    BestellingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestelDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotaalPrijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellingen", x => x.BestellingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WinkelmandjeItems_BestellingId",
                table: "WinkelmandjeItems",
                column: "BestellingId");

            migrationBuilder.AddForeignKey(
                name: "FK_WinkelmandjeItems_Bestellingen_BestellingId",
                table: "WinkelmandjeItems",
                column: "BestellingId",
                principalTable: "Bestellingen",
                principalColumn: "BestellingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WinkelmandjeItems_Bestellingen_BestellingId",
                table: "WinkelmandjeItems");

            migrationBuilder.DropTable(
                name: "Bestellingen");

            migrationBuilder.DropIndex(
                name: "IX_WinkelmandjeItems_BestellingId",
                table: "WinkelmandjeItems");

            migrationBuilder.DropColumn(
                name: "BestellingId",
                table: "WinkelmandjeItems");
        }
    }
}
