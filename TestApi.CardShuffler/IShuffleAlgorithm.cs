using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestApi.CardShuffler
{
    public interface IShuffleAlgorithm<T>
    {
        IEnumerable<T> Shuffle(IEnumerable<T> collection);
    }
}
