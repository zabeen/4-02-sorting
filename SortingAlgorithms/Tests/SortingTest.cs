using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms.Tests
{
    public class SortingTest<TSort> where TSort : ISorter, new()
    {
        private readonly ItemsToSort _items = new ItemsToSort();
        private readonly IEnumerable<int> _sortedItems;

        public SortingTest()
        {
            _sortedItems = new TSort().SortItems(_items.UnorderedItems);
        }

        public void SortedListLengthRemainsIdenticalToUnsorted()
        {
            Assert.AreEqual(_items.UnorderedItems.Count, _items.OrderedItems.Count);
            Assert.AreEqual(_items.UnorderedItems.Count, _sortedItems.Count());
        }

        public void ItemsAreInCorrectOrder()
        {
            for (var i = 0; i < _sortedItems.Count(); i++)
            {
                Assert.AreEqual(_sortedItems.ElementAt(i), _items.OrderedItems[i]);
            }
        }
    }
}
