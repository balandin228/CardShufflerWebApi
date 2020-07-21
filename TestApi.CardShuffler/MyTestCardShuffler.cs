using System;
using System.Collections.Generic;
using System.Text;

namespace TestApi.CardShuffler
{
    public class MyTestCardShuffler : Shuffler
    {
        public MyTestCardShuffler(IShuffleAlgorithm<int> algorithm) : base(algorithm)
        {
        }
    }
}
