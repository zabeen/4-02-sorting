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
                        var firstList = sorted.GetRange(i, listLength);
                        var secondList = sorted.GetRange(i + listLength, leftForSecond < listLength ? leftForSecond : listLength);
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
            var finalFirstList = sorted.GetRange(0, finalTakeCount);
            var finalSecondList = sorted.GetRange(finalTakeCount, itemsCount - finalTakeCount);
            return PerformMergeSort(finalFirstList, finalSecondList);
        }

        private IEnumerable<int> PerformMergeSort(IEnumerable<int> firstList, IEnumerable<int> secondList)
        {
            var firstQ = new Queue<int>(firstList);
            var secondQ = new Queue<int>(secondList);
            var merged = new List<int>();
            var mergedCount = firstQ.Count + secondQ.Count;

            for (var i = 0; i < mergedCount; i++)
            {
                if (firstQ.Count == 0)
                {
                    merged.AddRange(secondQ);
                    break;
                }

                if (secondQ.Count == 0)
                {
                    merged.AddRange(firstQ);
                    break;
                }

                merged.Add(firstQ.Peek() < secondQ.Peek() ? firstQ.Dequeue() : secondQ.Dequeue());
            }

            return merged;
        }
    }
}
