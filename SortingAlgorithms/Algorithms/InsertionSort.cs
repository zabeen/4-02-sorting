using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Algorithms
{
    public class InsertionSort : ISorter
    {
        public IEnumerable<int> SortItems(IEnumerable<int> itemsToSort)
        {
            var unsorted = new Queue<int>(itemsToSort);
            var sorted = new List<int> {unsorted.Dequeue()};

            while (unsorted.Count > 0)
            {
                var currentItem = unsorted.Dequeue();

                for (var i = 0; i < sorted.Count; i++)
                {
                    if (currentItem <= sorted[i])
                    {
                        sorted.Insert(i, currentItem);
                        break;
                    }

                    if (i == sorted.Count - 1)
                    {
                        sorted.Add(currentItem);
                        break;
                    }
                }
            }

            return sorted;
        }
    }
}
