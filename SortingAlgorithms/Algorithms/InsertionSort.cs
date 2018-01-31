using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Algorithms
{
    public class InsertionSort : ISorter
    {
        public IEnumerable<int> SortItems(IEnumerable<int> itemsToSort)
        {
            var unsorted = new Queue<int>(itemsToSort);
            var sorted = new List<int> { unsorted.Dequeue() };

            while (unsorted.Count > 0)
            {
                var currentItem = unsorted.Dequeue();

                for (var i = sorted.Count - 1; i > -1; i--)
                {
                    if (currentItem >= sorted[i])
                    {
                        if (i == sorted.Count - 1)
                            sorted.Add(currentItem);
                        else
                            sorted.Insert(i+1, currentItem);
                        break;
                    }

                    if (i == 0)
                    {
                        sorted.Insert(0, currentItem);
                        break;
                    }
                }
            }

            return sorted;
        }
    }
}
