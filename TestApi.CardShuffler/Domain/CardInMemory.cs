using TestApi.Core.Domain.Card;

namespace TestApi.Core.Domain
{
    public class CardInMemory
    {
        public CardInMemory()
        {
        }

        public CardInMemory(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public CardSuit Suit { get; }
        public CardRank Rank { get; }
    }
}