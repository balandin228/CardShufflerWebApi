using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestApi.CardShuffler
{
    public abstract class Shuffler<T> : IShuffler<T>
    {
        private readonly IShuffleAlgorithm _defaultAlgorithm;

        protected Shuffler(IShuffleAlgorithm algorithm)
        {
            _defaultAlgorithm = algorithm;
        }

        public IEnumerable<T> Shuffle(IEnumerable<T> collection)
        {
            return _defaultAlgorithm.Shuffle<T>(collection);
        }

        public IEnumerable<T> Shuffle(IEnumerable<T> collection, IShuffleAlgorithm algorithm)
        {
            return algorithm.Shuffle<T>(collection);
        }
    }
}
