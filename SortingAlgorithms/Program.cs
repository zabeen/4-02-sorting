using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms
{
    class Program
    {
        private const int SeedValue = 12345;
        private const int MinValue = 0;
        private const int MaxValue = 1000;
        private const int Count = 10;

        static void Main(string[] args)
        {
            Console.WriteLine($"Unsorted: [{string.Join(",", Generator.GenerateRandomNumbers(SeedValue, MinValue, MaxValue, Count))}]");
            PerformSort(new Sort(Generator.GenerateRandomNumbers(SeedValue, MinValue, MaxValue, Count)));
            PerformSort(new SelectionSort(Generator.GenerateRandomNumbers(SeedValue, MinValue, MaxValue, Count)));
            Console.ReadLine();
        }

        static void PerformSort(Sort sort)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sort.SortItems();
            sw.Stop();
            Console.WriteLine($"{sort}; {sw.Elapsed.TotalMilliseconds}ms");
        }
    }
}
