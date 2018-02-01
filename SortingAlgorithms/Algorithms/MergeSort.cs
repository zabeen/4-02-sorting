using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Algorithms
{
    public class MergeSort : ISorter
    {
        public IEnumerable<int> SortItems(IEnumerable<int> itemsToSort)
        {
            var sorted = itemsToSort.ToList();
            var itemsCount = sorted.Count;
            var takeCount = 2;

            while (takeCount < itemsCount)
            {
                var tempSortedList = new List<int>();

                for (int i = 0; i < itemsCount; i += takeCount)
                {
                    var listLength = takeCount / 2;
                    var totalLeft = itemsCount - i;
                    var leftForSecond = totalLeft - listLength;

                    if (totalLeft > listLength)
                    {
                        var firstList = new Queue<int>(sorted.GetRange(i, listLength));
                        var secondList = new Queue<int>(sorted.GetRange(i + listLength, leftForSecond < listLength ? leftForSecond : listLength));
                        tempSortedList.AddRange(PerformMergeSort(firstList, secondList));
                    }
                    else
                    {
                        tempSortedList.AddRange(sorted.GetRange(i, totalLeft));
                    }
                }

                sorted = tempSortedList;
                takeCount *= 2;
            }

            // final merge
            var finalTakeCount = takeCount / 2;
            var finalFirstList = new Queue<int>(sorted.GetRange(0, finalTakeCount));
            var finalSecondList = new Queue<int>(sorted.GetRange(finalTakeCount, itemsCount - finalTakeCount));
            return PerformMergeSort(finalFirstList, finalSecondList);
        }

        private IEnumerable<int> PerformMergeSort(Queue<int> firstList, Queue<int> secondList)
        {
            var merged = new List<int>();
            var mergedCount = firstList.Count + secondList.Count;

            for (var i = 0; i < mergedCount; i++)
            {
                if (firstList.Count == 0)
                {
                    merged.AddRange(secondList);
                    break;
                }

                if (secondList.Count == 0)
                {
                    merged.AddRange(firstList);
                    break;
                }

                merged.Add(firstList.Peek() < secondList.Peek() ? firstList.Dequeue() : secondList.Dequeue());
            }

            return merged;
        }
    }
}
