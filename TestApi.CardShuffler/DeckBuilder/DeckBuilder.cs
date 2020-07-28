using System.Collections.Generic;
using System.Linq;
using TestApi.Core.Domain;
using TestApi.Core.Shuffler;

namespace TestApi.Core.DeckBuilder
{
    public class DeckBuilder : IDeckBuilder
    {
        private readonly IShuffler _shuffler;

        public DeckBuilder()
        {
            Options = new DeckBuilderOptions();
            _shuffler = new DefaultShuffler();
            Cards = Options.Deck.ToList();
        }

        public DeckBuilder(IShuffler shuffler, DeckBuilderOptions options)
        {
            Options = options;
            Cards = Options.Deck.ToList();
            _shuffler = shuffler;
        }

        private DeckBuilderOptions Options { get; set; }
        public List<CardInMemory> Cards { get; private set; }

        public List<CardInMemory> Shuffle()
        {
            return _shuffler.Shuffle(Cards).ToList();
        }

        public List<T> Shuffle<T>(IEnumerable<T> collection)
        {
            return _shuffler.Shuffle(collection).ToList();
        }

        public List<CardInMemory> CreateDeck()
        {
            Cards = Options.Deck.ToList();
            return Cards;
        }

        public void ChangeOptions(DeckBuilderOptions options)
        {
            Options = options;
        }
    }
}