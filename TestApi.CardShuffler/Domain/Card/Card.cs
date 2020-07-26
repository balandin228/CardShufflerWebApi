using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Core.Domain.Card
{
    public class Card : Entity<long>, ICard
    {

        public CardRank Rank { get; }

        public CardSuit Suit { get; }

        public IQueryable<CardInDeck> CardInDecks { get; }
        public Card()
        {

        }

        public Card(CardSuit suit, CardRank rank)
        {
            Rank = rank;
            Suit = suit;
        }
        public Card(long key,CardSuit suit, CardRank rank): base(key)
        {
            Rank = rank;
            Suit = suit;
        }
    }
}
