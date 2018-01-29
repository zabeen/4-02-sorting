using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms.Tests
{
    [TestFixture]
    public class SortTest
    {
        private readonly List<int> _unorderedItems = new List<int>() { 1, 3, 2, 1, 4, 0, 4 };
        private readonly List<int> _orderedItems = new List<int>() { 0, 1, 1, 2, 3, 4, 4 };

        [Test]
        public void Sort_NumberOfItemsRemainsTheSame()
        {
            Sort sort = new Sort(_unorderedItems.Select(i => i).ToList());
            sort.SortItems();

            Assert.AreEqual(_unorderedItems.Count, sort.ItemsToSort.Count);
        }

        [Test]
        public void Sort_ItemsAreInCorrectOrder()
        {
            Sort sort = new Sort(_unorderedItems.Select(i => i).ToList());
            sort.SortItems();

            for (var i = 0; i < sort.ItemsToSort.Count; i++)
            {
                Assert.AreEqual(sort.ItemsToSort[i], _orderedItems[i]);
            }
        }
    }
}
