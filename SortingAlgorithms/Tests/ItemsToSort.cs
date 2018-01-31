using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Tests
{
    public class ItemsToSort
    {
        public readonly List<int> UnorderedItems = new List<int>() { 1, 3, -1, 2, 1, -1, 4, 0, -2, 4 };
        public readonly List<int> OrderedItems = new List<int>() { -2, -1, -1, 0, 1, 1, 2, 3, 4, 4 };
    }
}
