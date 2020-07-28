using System.Collections.Generic;

namespace TestApi.Core.Shuffler
{
    public interface IShuffler<T> : IShuffler
    {
        IEnumerable<T> Shuffle(IEnumerable<T> collection);
        IEnumerable<T> Shuffle(IEnumerable<T> collection, IShuffleAlgorithm algorithm);
    }
}