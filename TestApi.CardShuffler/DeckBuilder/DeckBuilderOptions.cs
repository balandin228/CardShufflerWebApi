using System;
using System.Collections.Generic;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Card;

namespace TestApi.Core.DeckBuilder
{
    public class DeckBuilderOptions
    {
        private static readonly Dictionary<DeckType, Func<IEnumerable<CardInMemory>>> DecksCreatingDictionary =
            new Dictionary<DeckType, Func<IEnumerable<CardInMemory>>>
            {
                {DeckType.Default, GetDefaultDeck},
                {DeckType.SmallDeck, GetSmallDeck}
            };

        public DeckBuilderOptions()
        {
            Type = DeckType.Default;
        }

        public DeckBuilderOptions(DeckType type)
        {
            Type = type;
        }

        public DeckType Type { get; }
        public IEnumerable<CardInMemory> Deck => DecksCreatingDictionary[Type]();

        private static IEnumerable<CardInMemory> GetDefaultDeck()
        {
            for (var i = 0; i < 14; i++)
            for (var j = 0; j < 4; j++)
                yield return new CardInMemory((CardSuit) j, (CardRank) i);
        }

        private static IEnumerable<CardInMemory> GetSmallDeck()
        {
            for (var i = 5; i < 14; i++)
            for (var j = 0; j < 4; j++)
                yield return new CardInMemory((CardSuit) j, (CardRank) i);
        }
    }
}