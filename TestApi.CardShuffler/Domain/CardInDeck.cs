using System;
using System.Collections.Generic;
using System.Text;

namespace TestApi.Core.Domain
{
    public class CardInDeck : Entity<long>
    {
        public long DeckId { get; }
        public long CardId { get; }
        public Card.Card Card { get; }

        public Deck.Deck Deck { get; }
        public CardInDeck()
        {

        }

        public CardInDeck(long deckId, long cardId)
        {
            DeckId = deckId;
            CardId = cardId;
        }
    }
}
