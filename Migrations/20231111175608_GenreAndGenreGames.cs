using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetGameShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class GenreAndGenreGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Genre_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Genre_ID);
                });

            migrationBuilder.CreateTable(
                name: "GenreGames",
                columns: table => new
                {
                    Game_ID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Genre_ID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreGames", x => x.Game_ID);
                    table.ForeignKey(
                        name: "FK_GenreGames_Genre_Genre_ID",
                        column: x => x.Genre_ID,
                        principalTable: "Genre",
                        principalColumn: "Genre_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreGames_Genre_ID",
                table: "GenreGames",
                column: "Genre_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreGames");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
