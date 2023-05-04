using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationToConcerts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Concerts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "somewhere");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Concerts");
        }
    }
}
