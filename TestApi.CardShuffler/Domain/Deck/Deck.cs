using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Core.Domain.Deck
{
    public class Deck : Entity<long>, IDeck
    {
        public virtual List<CardInDeck> CardInDecks { get; }
        public string Name { get; }

        public Deck()
        {
            CardInDecks = new List<CardInDeck>();
        }

        public Deck(string name)
        {
            Name = name;
        }
    }
}
