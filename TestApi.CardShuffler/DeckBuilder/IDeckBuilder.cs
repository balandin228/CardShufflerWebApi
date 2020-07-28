using System;
using System.Collections.Generic;
using System.Text;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Card;

namespace TestApi.Core.DeckBuilder
{
    public interface IDeckBuilder
    {
        List<CardInMemory> Cards { get; }
        List<CardInMemory> Shuffle();
        List<T> Shuffle<T>(IEnumerable<T> collection);
        List<CardInMemory> CreateDeck();
        void ChangeOptions(DeckBuilderOptions options);
    }
}
