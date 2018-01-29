using System.Collections.Generic;
using SortingAlgorithms.Algorithms;
using NUnit.Framework;

namespace SortingAlgorithms.Tests
{
    [TestFixture]
    public class SortingTestRunner
    {
        private readonly SortingTest<LinqSort> _defaultTest = new SortingTest<LinqSort>();
        private readonly SortingTest<SelectionSort> _selectionTest = new SortingTest<SelectionSort>();

        [Test]
        public void SortedListLengthRemainsIdenticalToUnsorted()
        {
            _defaultTest.SortedListLengthRemainsIdenticalToUnsorted();
            _selectionTest.SortedListLengthRemainsIdenticalToUnsorted();
        }

        [Test]
        public void ItemsAreInCorrectOrder()
        {
            _defaultTest.ItemsAreInCorrectOrder();
            _selectionTest.ItemsAreInCorrectOrder();
        }
    }
}
