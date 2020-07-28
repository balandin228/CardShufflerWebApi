using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Core.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<int>(nullable: false),
                    Suit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.UniqueConstraint("AK_Cards_Suit_Rank", x => new { x.Suit, x.Rank });
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardInDecks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckId = table.Column<long>(nullable: false),
                    CardId = table.Column<long>(nullable: false),
                    NumberInDeck = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInDecks", x => x.Id);
                    table.ForeignKey(
                        name: "Card",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Deck",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Rank", "Suit" },
                values: new object[,]
                {
                    { 1L, 0, 0 },
                    { 31L, 2, 7 },
                    { 32L, 3, 7 },
                    { 33L, 0, 8 },
                    { 34L, 1, 8 },
                    { 35L, 2, 8 },
                    { 36L, 3, 8 },
                    { 37L, 0, 9 },
                    { 38L, 1, 9 },
                    { 39L, 2, 9 },
                    { 40L, 3, 9 },
                    { 41L, 0, 10 },
                    { 30L, 1, 7 },
                    { 42L, 1, 10 },
                    { 44L, 3, 10 },
                    { 45L, 0, 11 },
                    { 46L, 1, 11 },
                    { 47L, 2, 11 },
                    { 48L, 3, 11 },
                    { 49L, 0, 12 },
                    { 50L, 1, 12 },
                    { 51L, 2, 12 },
                    { 52L, 3, 12 },
                    { 53L, 0, 13 },
                    { 54L, 1, 13 },
                    { 43L, 2, 10 },
                    { 29L, 0, 7 },
                    { 28L, 3, 6 },
                    { 27L, 2, 6 },
                    { 2L, 1, 0 },
                    { 3L, 2, 0 },
                    { 4L, 3, 0 },
                    { 5L, 0, 1 },
                    { 6L, 1, 1 },
                    { 7L, 2, 1 },
                    { 8L, 3, 1 },
                    { 9L, 0, 2 },
                    { 10L, 1, 2 },
                    { 11L, 2, 2 },
                    { 12L, 3, 2 },
                    { 13L, 0, 3 },
                    { 14L, 1, 3 },
                    { 15L, 2, 3 },
                    { 16L, 3, 3 },
                    { 17L, 0, 4 },
                    { 18L, 1, 4 },
                    { 19L, 2, 4 },
                    { 20L, 3, 4 },
                    { 21L, 0, 5 },
                    { 22L, 1, 5 },
                    { 23L, 2, 5 },
                    { 24L, 3, 5 },
                    { 25L, 0, 6 },
                    { 26L, 1, 6 },
                    { 55L, 2, 13 },
                    { 56L, 3, 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardInDecks_CardId",
                table: "CardInDecks",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardInDecks_DeckId",
                table: "CardInDecks",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_Name",
                table: "Decks",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardInDecks");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decks");
        }
    }
}
