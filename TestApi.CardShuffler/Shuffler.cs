using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestApi.CardShuffler
{
    public abstract class Shuffler : IShuffler
    {
        private readonly IShuffleAlgorithm<int> _defaultAlgorithm;

        protected Shuffler(IShuffleAlgorithm<int> algorithm)
        {
            _defaultAlgorithm = algorithm;
        }

        public IEnumerable<int> Shuffle(IEnumerable<int> collection)
        {
            return _defaultAlgorithm.Shuffle(collection);
        }

        public IEnumerable<int> Shuffle(IEnumerable<int> collection, IShuffleAlgorithm<int> algorithm)
        {
            return algorithm.Shuffle(collection);
        }
    }
}
