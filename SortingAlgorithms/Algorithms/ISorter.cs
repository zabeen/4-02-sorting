using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Algorithms
{
    public interface ISorter
    {
        IEnumerable<int> SortItems(IEnumerable<int> itemsToSort);
    }

    public class Sort : ISorter
    {
        public virtual IEnumerable<int> SortItems(IEnumerable<int> itemsToSort)
        {
            // use the in-built sort
            return itemsToSort.OrderBy(i => i).ToList();
        }
    }
}
