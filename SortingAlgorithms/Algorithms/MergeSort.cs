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
                //var noOfLists = Math.Ceiling((double)itemsCount / takeCount);

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
            var finalTake = takeCount / 2;
            var finalFirst = new Queue<int>(sorted.GetRange(0, finalTake));
            var finalSecond = new Queue<int>(sorted.GetRange(finalTake, itemsCount - finalTake));
            return PerformMergeSort(finalFirst, finalSecond);
        }

        private IEnumerable<int> PerformMergeSort(Queue<int> firstList, Queue<int> secondList)
        {
            var tempSortedList = new List<int>();
            var mergedCount = firstList.Count + secondList.Count;

            for (var i = 0; i < mergedCount; i++)
            {
                if (firstList.Count == 0)
                {
                    tempSortedList.AddRange(secondList);
                    break;
                }

                if (secondList.Count == 0)
                {
                    tempSortedList.AddRange(firstList);
                    break;
                }

                tempSortedList.Add(firstList.Peek() < secondList.Peek() ? firstList.Dequeue() : secondList.Dequeue());
            }

            return tempSortedList;
        }
    }
}
