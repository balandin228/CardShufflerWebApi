using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Core.Domain.Card;

namespace TestApi.Web.Dtos
{
    public class CardDto
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }

        public CardDto(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public CardDto()
        {
        }
    }
}
