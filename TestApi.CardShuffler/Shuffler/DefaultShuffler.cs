using System;
using System.Collections.Generic;
using System.Text;

namespace TestApi.Core.Shuffler
{
    public class DefaultShuffler : Shuffler
    {
        public DefaultShuffler() : base()
        {
        }

        public DefaultShuffler(IShuffleAlgorithm algorithm) : base(algorithm)
        {
        }
    }
}
