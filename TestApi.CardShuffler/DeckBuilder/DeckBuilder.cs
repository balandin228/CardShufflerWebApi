using System;
using System.Collections.Generic;
using System.Text;
using TestApi.Core.Domain.Card;
using TestApi.Core.Domain.Deck;
using TestApi.Core.Shuffler;

namespace TestApi.Core.DeckBuilder
{
    public abstract class DeckBuilder
    {
        private readonly IShuffler _shuffler;
        public IEnumerable<Card> Cards { get; private set; }
        protected DeckBuilder()
        {
            Cards = new DeckBuilderOptions().Deck;
            _shuffler = new DefaultShuffler();
        }

        protected DeckBuilder(IShuffler shuffler,DeckBuilderOptions options)
        {
            Cards = options.Deck;
            _shuffler = shuffler;
        }

        public IEnumerable<Card> Shuffle()
        {
           return _shuffler.Shuffle(Cards);
        }

        public IEnumerable<Card> ChangeDeck(IEnumerable<Card> cards)
        {
            Cards = cards;
            return Cards;
        }

        public IEnumerable<Card> ChangeDeck(DeckBuilderOptions options)
        {
            Cards = options.Deck;
            return Cards;
        }

    }
}
