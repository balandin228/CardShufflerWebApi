using System;
using System.Collections.Generic;
using System.Text;
using TestApi.Core.Domain.Card;

namespace TestApi.Core.DeckBuilder
{
    public interface IDeckBuilder
    {
        IEnumerable<Card> Cards { get; }
        IEnumerable<Card> Shuffle();
        IEnumerable<Card> ChangeDeck(IEnumerable<Card> cards);
    }
}
