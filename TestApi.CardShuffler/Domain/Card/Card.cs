using System.Collections.Generic;

namespace TestApi.Core.Domain.Card
{
    public class Card : Entity<long>, ICard
    {
        public Card()
        {
            CardInDecks = new List<CardInDeck>();
        }

        public Card(CardSuit suit, CardRank rank)
        {
            Rank = rank;
            Suit = suit;
        }

        public Card(long key, CardSuit suit, CardRank rank) : base(key)
        {
            Suit = suit;
            Rank = rank;
        }


        public List<CardInDeck> CardInDecks { get; }

        public CardSuit Suit { get; }
        public CardRank Rank { get; }
    }
}