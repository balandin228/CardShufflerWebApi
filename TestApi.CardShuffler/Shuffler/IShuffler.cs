using System;
using System.Collections.Generic;
using System.Text;

namespace TestApi.Core.Shuffler
{
    public interface IShuffler
    {
        /// <summary>
        /// Use default algorithm to shuffle
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IEnumerable<T> Shuffle<T>(IEnumerable<T> collection);
        /// <summary>
        /// Use custom algorithm to shuffle
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="algorithm"> algorithm to shuffle</param>
        /// <returns></returns>
        IEnumerable<T> Shuffle<T>(IEnumerable<T> collection, IShuffleAlgorithm algorithm);
    }
}
