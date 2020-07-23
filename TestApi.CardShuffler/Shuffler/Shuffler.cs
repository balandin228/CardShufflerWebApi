using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestApi.Core.Shuffler
{
    public abstract class Shuffler : IShuffler
    {
        private readonly IShuffleAlgorithm _defaultAlgorithm;


        protected Shuffler()
        {
            _defaultAlgorithm = new FisherYatesAlgorithm();
        }
        protected Shuffler(IShuffleAlgorithm algorithm)
        {
            _defaultAlgorithm = algorithm;
        }

        public virtual IEnumerable<T> Shuffle<T>(IEnumerable<T> collection)
        {
            return _defaultAlgorithm.Shuffle(collection);
        }

        public virtual IEnumerable<T> Shuffle<T>(IEnumerable<T> collection, IShuffleAlgorithm algorithm)
        {
            return algorithm.Shuffle(collection);
        }
    }
}
