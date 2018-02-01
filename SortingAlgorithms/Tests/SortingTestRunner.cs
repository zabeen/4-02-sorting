using System.Collections.Generic;
using SortingAlgorithms.Algorithms;
using NUnit.Framework;

namespace SortingAlgorithms.Tests
{
    [TestFixture]
    public class SortingTestRunner
    {
        private readonly SortingTest<ListSort> _listTest = new SortingTest<ListSort>();
        private readonly SortingTest<SelectionSort> _selectionTest = new SortingTest<SelectionSort>();
        private  readonly SortingTest<InsertionSort> _insertionTest = new SortingTest<InsertionSort>();
        private readonly SortingTest<MergeSort> _mergeTest = new SortingTest<MergeSort>();

        [Test]
        public void SortedListLengthRemainsIdenticalToUnsorted()
        {
            _listTest.SortedListLengthRemainsIdenticalToUnsorted();
            _selectionTest.SortedListLengthRemainsIdenticalToUnsorted();
            _insertionTest.SortedListLengthRemainsIdenticalToUnsorted();
            _mergeTest.SortedListLengthRemainsIdenticalToUnsorted();
        }

        [Test]
        public void ItemsAreInCorrectOrder()
        {
            _listTest.ItemsAreInCorrectOrder();
            _selectionTest.ItemsAreInCorrectOrder();
            _insertionTest.ItemsAreInCorrectOrder();
            _mergeTest.ItemsAreInCorrectOrder();
        }
    }
}
