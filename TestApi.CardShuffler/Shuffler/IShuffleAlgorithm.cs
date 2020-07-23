using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestApi.Core.Shuffler
{
    public interface IShuffleAlgorithm
    {
        IEnumerable<T> Shuffle<T>(IEnumerable<T> collection);
    }
}
