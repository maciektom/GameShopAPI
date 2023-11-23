using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetGameShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class usergamestest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames");

            migrationBuilder.DropIndex(
                name: "IX_UserGames_User_ID",
                table: "UserGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames",
                columns: new[] { "User_ID", "Game_ID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames",
                column: "Game_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_User_ID",
                table: "UserGames",
                column: "User_ID");
        }
    }
}
