using System;
using System.Collections.Generic;
using System.Text;

namespace TestApi.CardShuffler
{
    public interface IShuffler<T>
    {
        /// <summary>
        /// Use default algorithm to shuffle
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IEnumerable<T> Shuffle(IEnumerable<T> collection);
        /// <summary>
        /// Use custom algorithm to shuffle
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="algorithm"> algorithm to shuffle</param>
        /// <returns></returns>
        IEnumerable<T> Shuffle(IEnumerable<T> collection, IShuffleAlgorithm algorithm);
    }
}
