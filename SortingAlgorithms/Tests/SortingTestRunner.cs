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
        private  readonly SortingTest<InsertionSort> _insertionTest = new SortingTest<InsertionSort>();
        private readonly SortingTest<MergeSort> _mergeTest = new SortingTest<MergeSort>();

        [Test]
        public void SortedListLengthRemainsIdenticalToUnsorted()
        {
            _defaultTest.SortedListLengthRemainsIdenticalToUnsorted();
            _selectionTest.SortedListLengthRemainsIdenticalToUnsorted();
            _insertionTest.SortedListLengthRemainsIdenticalToUnsorted();
            _mergeTest.SortedListLengthRemainsIdenticalToUnsorted();
        }

        [Test]
        public void ItemsAreInCorrectOrder()
        {
            _defaultTest.ItemsAreInCorrectOrder();
            _selectionTest.ItemsAreInCorrectOrder();
            _insertionTest.ItemsAreInCorrectOrder();
            _mergeTest.ItemsAreInCorrectOrder();
        }
    }
}
