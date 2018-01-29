using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms
{
    class Program
    {
        
        private const int SeedValue = 1;
        private const int MinValue = 0;
        private const int MaxValue = 1000;
        private const int Count = 10;

        static void Main(string[] args)
        {
            Console.WriteLine($"Unsorted: [{string.Join(",", Generator.GenerateRandomNumbers(SeedValue, MinValue, MaxValue, Count))}]");
            PerformSort(new LinqSort());
            PerformSort(new SelectionSort());
            Console.ReadLine();
        }

        static void PerformSort(ISorter sort)
        {
            var items = Generator.GenerateRandomNumbers(SeedValue, MinValue, MaxValue, Count);

            Stopwatch sw = Stopwatch.StartNew();
            var sortedItems = sort.SortItems(items);
            sw.Stop();

            Console.WriteLine($"{sort.GetType().Name}: [{string.Join(",", sortedItems)}]; {sw.Elapsed.TotalMilliseconds}ms");
        }
    }
}
