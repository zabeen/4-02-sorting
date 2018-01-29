using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Algorithms
{
    public class DefaultSort : ISorter
    {
        public virtual IEnumerable<int> SortItems(IEnumerable<int> itemsToSort)
        {
            // use the in-built sort
            var items = itemsToSort.ToList();
            items.Sort();
            return items;
        }
    }
}
