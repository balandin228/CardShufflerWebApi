using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Card;
using TestApi.Core.Domain.Deck;

namespace TestApi.Core.DeckBuilder
{
    public class DeckBuilderOptions
    {
        public DeckType Type { get; }

        private static readonly Dictionary<DeckType, Func<IEnumerable<CardInMemory>>> DecksCreatingDictionary =
            new Dictionary<DeckType, Func<IEnumerable<CardInMemory>>>()
            {
                {DeckType.Default,GetDefaultDeck},
                {DeckType.SmallDeck,GetSmallDeck}
            };
        public IEnumerable<CardInMemory> Deck => DecksCreatingDictionary[Type]();

        public DeckBuilderOptions()
        {
            Type = DeckType.Default;
        }

        public DeckBuilderOptions(DeckType type)
        {
            Type = type;
        }

        private static IEnumerable<CardInMemory> GetDefaultDeck()
        {

            for (var i = 0; i < 14; i++)
                for (var j = 0; j < 4; j++)
                    yield return new CardInMemory((CardSuit)i, (CardRank)j);
        }

        private static IEnumerable<CardInMemory> GetSmallDeck()
        {
            for (var i = 5; i < 14; i++)
                for (var j = 0; j < 4; j++)
                    yield return new CardInMemory((CardSuit)i, (CardRank)j);
        }
    }
}
