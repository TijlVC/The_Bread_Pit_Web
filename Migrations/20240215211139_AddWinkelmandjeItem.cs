using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Bread_Pit.Migrations
{
    /// <inheritdoc />
    public partial class AddWinkelmandjeItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_WinkelmandjeItems_ProduktProductID",
                table: "WinkelmandjeItems",
                column: "ProduktProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WinkelmandjeItems");
        }
    }
}
