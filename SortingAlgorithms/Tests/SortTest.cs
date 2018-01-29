using NUnit.Framework;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms.Tests
{
    public class SortTest
    {
        private readonly ItemsToSort _items = new ItemsToSort();
        private readonly Sort _sort;

        public SortTest(Sort sort)
        {
            _sort = sort;
            _sort.SortItems();
        }

        public void SortedListLengthRemainsIdenticalToUnsorted()
        {
            Assert.AreEqual(_items.UnorderedItems.Count, _items.OrderedItems.Count);
            Assert.AreEqual(_items.UnorderedItems.Count, _sort.ItemsToSort.Count);
        }

        public void ItemsAreInCorrectOrder()
        {
            for (var i = 0; i < _sort.ItemsToSort.Count; i++)
            {
                Assert.AreEqual(_sort.ItemsToSort[i], _items.OrderedItems[i]);
            }
        }
    }
}
