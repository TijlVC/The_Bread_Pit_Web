using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Bread_Pit.Data.Migrations
{
    public partial class AddBestelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotaalPrijs",
                table: "Bestellingen");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bestellingen",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsAfgerond",
                table: "Bestellingen",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "IsAfgerond",
                table: "Bestellingen");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bestellingen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<decimal>(
                name: "TotaalPrijs",
                table: "Bestellingen",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
