using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Algorithms
{
    public class SelectionSort : ISorter
    {
        public IEnumerable<int> SortItems(IEnumerable<int> itemsToSort)
        {
            var startingIndex = 0;
            var items = itemsToSort.ToList();
            var smallestItemIndex = startingIndex;
            
            do
            {
                int smallestItemValue = items[startingIndex];
                for (var i = startingIndex; i < items.Count; i++)
                {
                    if (items[i] <= smallestItemValue)
                    {
                        smallestItemIndex = i;
                        smallestItemValue = items[i];
                    }
                }

                items.RemoveAt(smallestItemIndex);
                items.Insert(startingIndex,smallestItemValue);
                startingIndex++;

            } while (startingIndex < items.Count-1);

            return items;
        }
    }
}
