using System.Collections.Generic;

namespace TestApi.Core.Domain.Deck
{
    public class Deck : Entity<long>, IDeck
    {
        public Deck()
        {
            CardInDecks = new List<CardInDeck>();
        }

        public Deck(string name)
        {
            Name = name;
        }

        public virtual List<CardInDeck> CardInDecks { get; }
        public string Name { get; }
    }
}