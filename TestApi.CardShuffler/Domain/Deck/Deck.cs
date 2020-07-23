using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Web.Domain.Deck
{
    public class Deck : Entity<long>, IDeck
    {
        public IEnumerable<Card.Card> Cards;

        public Deck()
        {
        }
    }
}
