using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Algorithms
{
    public class Sort
    {
        protected List<int> ItemsToSort;

        public Sort(IEnumerable<int> itemsToSort)
        {
            ItemsToSort = itemsToSort.ToList();
        }

        public override string ToString()
        {
            return $"{GetType().Name}: [{string.Join(",", ItemsToSort)}]";
        }

        public virtual void SortItems()
        {
            // default is the in-built sort
            ItemsToSort.Sort();
        }
    }
}
