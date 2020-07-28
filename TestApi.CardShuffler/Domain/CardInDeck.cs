namespace TestApi.Core.Domain
{
    public class CardInDeck : Entity<long>
    {
        public CardInDeck()
        {
        }

        public CardInDeck(long deckId, long cardId, int numberInDeck)
        {
            NumberInDeck = numberInDeck;
            DeckId = deckId;
            CardId = cardId;
        }

        public long DeckId { get; set; }
        public long CardId { get; set; }
        public virtual Card.Card Card { get; }
        public int NumberInDeck { get; set; }
        public Deck.Deck Deck { get; }
    }
}