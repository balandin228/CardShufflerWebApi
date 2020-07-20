using System;
using System.Collections.Generic;
using System.Text;

namespace TestApi.CardShuffler
{
    public class MyTestCardShuffler : Shuffler<Object>
    {
        public MyTestCardShuffler(IShuffleAlgorithm algorithm) : base(algorithm)
        {
        }
    }
}
