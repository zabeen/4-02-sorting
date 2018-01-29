using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public static class Generator
    {
        /// <summary>
        /// Generates list of random numbers.
        /// Code adapted from this example: http://james-ramsden.com/create-a-list-of-random-numbers-in-c/
        /// </summary>
        public static IEnumerable<int> GenerateRandomNumbers(int seedValue, int minValue, int maxValue, int count)
        {      
            var rand = new Random(seedValue);
            var rtnlist = new List<int>();

            for (var i = 0; i < count; i++)
            {
                rtnlist.Add(rand.Next(minValue, maxValue));
            }

            return rtnlist;
        }
    }
}
