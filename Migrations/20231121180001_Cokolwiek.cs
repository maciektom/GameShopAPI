using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetGameShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class Cokolwiek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Pegi",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pegi",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
