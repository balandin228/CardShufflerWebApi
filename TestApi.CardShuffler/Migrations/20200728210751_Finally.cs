using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Core.Migrations
{
    public partial class Finally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Cards",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suit = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.UniqueConstraint("AK_Cards_Rank_Suit", x => new {x.Rank, x.Suit});
                });

            migrationBuilder.CreateTable(
                "Decks",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Decks", x => x.Id); });

            migrationBuilder.CreateTable(
                "CardInDecks",
                table => new
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
                        "Card",
                        x => x.CardId,
                        "Cards",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "Deck",
                        x => x.DeckId,
                        "Decks",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "Cards",
                new[] {"Id", "Rank", "Suit"},
                new object[,]
                {
                    {1L, 0, 0},
                    {31L, 7, 2},
                    {32L, 7, 3},
                    {33L, 8, 0},
                    {34L, 8, 1},
                    {35L, 8, 2},
                    {36L, 8, 3},
                    {37L, 9, 0},
                    {38L, 9, 1},
                    {39L, 9, 2},
                    {40L, 9, 3},
                    {41L, 10, 0},
                    {30L, 7, 1},
                    {42L, 10, 1},
                    {44L, 10, 3},
                    {45L, 11, 0},
                    {46L, 11, 1},
                    {47L, 11, 2},
                    {48L, 11, 3},
                    {49L, 12, 0},
                    {50L, 12, 1},
                    {51L, 12, 2},
                    {52L, 12, 3},
                    {53L, 13, 0},
                    {54L, 13, 1},
                    {43L, 10, 2},
                    {29L, 7, 0},
                    {28L, 6, 3},
                    {27L, 6, 2},
                    {2L, 0, 1},
                    {3L, 0, 2},
                    {4L, 0, 3},
                    {5L, 1, 0},
                    {6L, 1, 1},
                    {7L, 1, 2},
                    {8L, 1, 3},
                    {9L, 2, 0},
                    {10L, 2, 1},
                    {11L, 2, 2},
                    {12L, 2, 3},
                    {13L, 3, 0},
                    {14L, 3, 1},
                    {15L, 3, 2},
                    {16L, 3, 3},
                    {17L, 4, 0},
                    {18L, 4, 1},
                    {19L, 4, 2},
                    {20L, 4, 3},
                    {21L, 5, 0},
                    {22L, 5, 1},
                    {23L, 5, 2},
                    {24L, 5, 3},
                    {25L, 6, 0},
                    {26L, 6, 1},
                    {55L, 13, 2},
                    {56L, 13, 3}
                });

            migrationBuilder.CreateIndex(
                "IX_CardInDecks_CardId",
                "CardInDecks",
                "CardId");

            migrationBuilder.CreateIndex(
                "IX_CardInDecks_DeckId",
                "CardInDecks",
                "DeckId");

            migrationBuilder.CreateIndex(
                "IX_Decks_Name",
                "Decks",
                "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CardInDecks");

            migrationBuilder.DropTable(
                "Cards");

            migrationBuilder.DropTable(
                "Decks");
        }
    }
}