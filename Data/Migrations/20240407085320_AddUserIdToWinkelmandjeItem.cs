using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Bread_Pit.Data.Migrations
{
    public partial class AddUserIdToWinkelmandjeItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WinkelmandjeItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WinkelmandjeItems_UserId",
                table: "WinkelmandjeItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WinkelmandjeItems_AspNetUsers_UserId",
                table: "WinkelmandjeItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WinkelmandjeItems_AspNetUsers_UserId",
                table: "WinkelmandjeItems");

            migrationBuilder.DropIndex(
                name: "IX_WinkelmandjeItems_UserId",
                table: "WinkelmandjeItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WinkelmandjeItems");
        }
    }
}
