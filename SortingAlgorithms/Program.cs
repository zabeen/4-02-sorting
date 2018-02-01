using SortingAlgorithms.Algorithms;
using SortingAlgorithms.Tests;
using System;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[U] = Unordered, [O] = Ordered\n");
            
            var selectionTask = Task.Run(() => WriteTimePerformance<SelectionSort>());
            var insertionTask = Task.Run(() => WriteTimePerformance<InsertionSort>());
            var linqTask = Task.Run(() => WriteTimePerformance<LinqSort>());
            var mergeTask = Task.Run(() => WriteTimePerformance<MergeSort>());


            selectionTask.Wait();
            insertionTask.Wait();
            linqTask.Wait();
            mergeTask.Wait();

            Console.WriteLine("\nAll done!");
            Console.ReadLine();
        }

        static void WriteTimePerformance<TSort>() where TSort: ISorter, new()
        {
            const int seedValue = 12345678;
            const int minValue = 0;
            const int maxValue = 1000000000;
            const int count = 1000;
            int[] sizeIncrements = {1, 2, 4, 10, 100};

            var test = new TimeTest<TSort>(seedValue, minValue, maxValue, count, sizeIncrements, 0);
            test.AssessSortPerformance();

            Console.WriteLine($"{typeof(TSort).Name}\n{test}\n");
        }
    }
}
