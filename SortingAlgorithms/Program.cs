using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Unsorted: [{string.Join(",", GenerateRandomNumbers(0, 0, 100, 10))}]");
            PerformSort(new Sort(GenerateRandomNumbers(0, 0, 100, 10)));
            PerformSort(new Selection(GenerateRandomNumbers(0, 0, 100, 10)));
            Console.ReadLine();
        }

        static void PerformSort(Sort sort)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sort.SortItems();
            sw.Stop();
            Console.WriteLine($"{sort}; {sw.Elapsed.TotalMilliseconds}ms");
        }

        /// <summary>
        /// Generates list of random numbers.
        /// Code adapted from this example: http://james-ramsden.com/create-a-list-of-random-numbers-in-c/
        /// </summary>
        static IEnumerable<int> GenerateRandomNumbers(int seedValue, int minValue, int maxValue, int count)
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
