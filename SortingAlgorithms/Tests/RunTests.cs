using System.Collections.Generic;
using SortingAlgorithms.Algorithms;
using NUnit.Framework;

namespace SortingAlgorithms.Tests
{
    [TestFixture]
    public class RunTests
    {
        ItemsToSort items = new ItemsToSort();
        List<SortTest> tests = new List<SortTest>();

        public RunTests()
        {
            tests.Add(new SortTest(new Sort(items.UnorderedItems)));
            tests.Add(new SortTest(new SelectionSort(items.UnorderedItems)));
        }

        [Test]
        public void SortedListLengthRemainsIdenticalToUnsorted()
        {
            foreach (var test in tests)
            {
                test.SortedListLengthRemainsIdenticalToUnsorted();
            }
        }

        [Test]
        public void ItemsAreInCorrectOrder()
        {
            foreach (var test in tests)
            {
                test.ItemsAreInCorrectOrder();
            }
        }
    }
}
