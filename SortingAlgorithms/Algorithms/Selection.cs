using System.Collections.Generic;

namespace SortingAlgorithms.Algorithms
{
    public class Selection : Sort
    {
        private int _startingIndex;

        public Selection(IEnumerable<int> itemsToSort) : base(itemsToSort) {}

        public override void SortItems()
        {
            var smallestItemIndex = _startingIndex;
            
            do
            {
                int smallestItemValue = ItemsToSort[_startingIndex];
                for (var i = _startingIndex; i < ItemsToSort.Count; i++)
                {
                    if (ItemsToSort[i] <= smallestItemValue)
                    {
                        smallestItemIndex = i;
                        smallestItemValue = ItemsToSort[i];
                    }
                }

                ItemsToSort.RemoveAt(smallestItemIndex);
                ItemsToSort.Insert(_startingIndex,smallestItemValue);
                _startingIndex++;

            } while (_startingIndex < ItemsToSort.Count-1);
        }
    }
}
