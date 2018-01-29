using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms
{
    class Program
    {
        private const int SeedValue = 0;
        private const int MinValue = 0;
        private const int MaxValue = 100;
        private const int Count = 10;

        static void Main(string[] args)
        {
            Console.WriteLine($"Unsorted: [{string.Join(",", GenerateRandomNumbers())}]");
            PerformSort(new Sort(GenerateRandomNumbers()));
            PerformSort(new Selection(GenerateRandomNumbers()));
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
        static IEnumerable<int> GenerateRandomNumbers()
        {
            var rand = new Random(SeedValue);
            var rtnlist = new List<int>();

            for (var i = 0; i < Count; i++)
            {
                rtnlist.Add(rand.Next(MinValue, MaxValue));
            }

            return rtnlist;
        }
    }
}
