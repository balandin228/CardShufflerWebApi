using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TestApi.Core.Shuffler
{
    public class FisherYatesAlgorithm : IShuffleAlgorithm
    {
        private readonly Random _random;

        public FisherYatesAlgorithm()
        {
            _random = new Random(DateTime.Now.Millisecond);
        }
        public IEnumerable<T> Shuffle<T>(IEnumerable<T> collection)
        {
            var result = new List<T>();
            foreach (var obj in collection)
            {
                var j = _random.Next(result.Count + 1);
                if (j == result.Count)
                    result.Add(obj);
                else
                {
                    result.Add(result[j]);
                    result[j] = obj;
                }
            }

            return result;
        }
    }
}
