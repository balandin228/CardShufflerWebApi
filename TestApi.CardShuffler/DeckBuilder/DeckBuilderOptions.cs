using System;
using System.Collections.Generic;
using System.Text;
using TestApi.Core.Domain.Card;
using TestApi.Core.Domain.Deck;

namespace TestApi.Core.DeckBuilder
{
    public class DeckBuilderOptions
    {
        public DeckType Type { get; }

        private static readonly Dictionary<DeckType, Func<IEnumerable<Card>>> DecksCreatingDictionary =
            new Dictionary<DeckType, Func<IEnumerable<Card>>>()
            {
                {DeckType.Default,GetDefaultDeck},
                {DeckType.SmallDeck,GetSmallDeck}
            };
        public IEnumerable<Card> Deck => DecksCreatingDictionary[Type]();

        public DeckBuilderOptions()
        {
            Type = DeckType.Default;
        }

        public DeckBuilderOptions(DeckType type)
        {
            Type = type;
        }

        private static IEnumerable<Card> GetDefaultDeck()
        {

            for(var i=0;i<14;i++)
                for(var j=0;j<4;j++)
                    yield return new Card((CardSuit)i,(CardRank)j);
        }

        private static IEnumerable<Card> GetSmallDeck()
        {
            for (var i = 5; i < 14; i++)
                for (var j = 0; j < 4; j++)
                    yield return new Card((CardSuit)i, (CardRank)j);
        }
    }
}
