using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SortingAlgorithms.Algorithms;
using SortingAlgorithms.Tests;

namespace SortingAlgorithms
{
    public class Performance
    {
        public string SortType { get; set; }
        public int Count { get; set; }
        public int Duration { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WriteTimePerformance<LinqSort>();
            WriteTimePerformance<InsertionSort>();
            WriteTimePerformance<SelectionSort>();

            Console.WriteLine("\nAll done!");
            Console.ReadLine();
        }

        static void WriteTimePerformance<TSort>() where TSort: ISorter, new()
        {
            const int seedValue = 1;
            const int minValue = 0;
            const int maxValue = 1000000000;
            const int count = 100000;
            int[] sizeIncrements = {1, 1, 2, 4};

            Console.WriteLine($"Running {typeof(TSort).Name}...");
            var test = new TimeTest<TSort>(seedValue, minValue, maxValue, count, sizeIncrements, 1);
            test.AssessSortPerformance();
            Console.WriteLine($"{test}\n");
        }
    }
}
