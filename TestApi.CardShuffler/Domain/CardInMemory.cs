using System;
using System.Collections.Generic;
using System.Text;
using TestApi.Core.Domain.Card;

namespace TestApi.Core.Domain
{
    public class CardInMemory
    {
        public CardSuit Suit { get; }
        public CardRank Rank { get; }

        public CardInMemory()
        {
        }

        public CardInMemory(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
