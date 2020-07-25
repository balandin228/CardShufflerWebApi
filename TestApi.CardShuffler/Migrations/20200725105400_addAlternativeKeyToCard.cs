using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Core.Migrations
{
    public partial class addAlternativeKeyToCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Suit",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Cards_Suit_Rank",
                table: "Cards",
                columns: new[] { "Suit", "Rank" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Cards_Suit_Rank",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Suit",
                table: "Cards");
        }
    }
}
