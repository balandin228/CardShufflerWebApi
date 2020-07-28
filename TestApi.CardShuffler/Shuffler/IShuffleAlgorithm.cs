using System.Collections.Generic;

namespace TestApi.Core.Shuffler
{
    public interface IShuffleAlgorithm
    {
        IEnumerable<T> Shuffle<T>(IEnumerable<T> collection);
    }
}