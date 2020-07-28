using TestApi.Core.Domain.Card;

namespace TestApi.Web.Dtos
{
    public class CardDto
    {
        public CardDto(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public CardDto()
        {
        }

        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
    }
}