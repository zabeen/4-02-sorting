using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms.Tests
{
    public class Performance
    {
        public int ItemCount { get; set; }
        public double UnorderedTimeMs { get; set; }
        public double OrderedTimeMs { get; set; }
    }

    public class TimeTest<TSort> where TSort : ISorter, new()
    {
        private List<Performance> _performances = new List<Performance>();
        private TSort _sort = new TSort();
        private readonly int _seedValue;
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly int _count;
        private readonly IEnumerable<int> _sizeIncrements;
        private readonly int _baselineIndex;

        public TimeTest(int seedValue, int minValue, int maxValue, int count, IEnumerable<int> sizeIncrements, int baselineIndex)
        {
            _seedValue = seedValue;
            _minValue = minValue;
            _maxValue = maxValue;
            _count = count;
            _sizeIncrements = sizeIncrements;
            _baselineIndex = baselineIndex;
        }

        public override string ToString()
        {
            var size = _performances[_baselineIndex].ItemCount;
            var utime = _performances[_baselineIndex].UnorderedTimeMs;
            var otime = _performances[_baselineIndex].OrderedTimeMs;

            return string.Join("\n", _performances.OrderBy(p => p.ItemCount).Select(p => 
                $"{p.ItemCount:N0} items, [U] {p.UnorderedTimeMs:F2}ms, [O] {p.OrderedTimeMs:F2}ms; " +
                $"size: x{p.ItemCount / size:N0} => time: [U] x{p.UnorderedTimeMs / utime:N1}, [O] x{p.OrderedTimeMs / otime:N1}"
                ).ToList());
        }

        public List<Performance> AssessSortPerformance()
        {
            foreach (var increment in _sizeIncrements)
            {
                Performance performance = new Performance() { ItemCount = _count * increment };

                var unordered = Generator.GenerateRandomNumbers(_seedValue, _minValue, _maxValue, performance.ItemCount);
                List<int> ordered = Generator.GenerateRandomNumbers(_seedValue, _minValue, _maxValue, performance.ItemCount).OrderBy(i => i).ToList();

                performance.UnorderedTimeMs = TimeSort(unordered);
                performance.OrderedTimeMs = TimeSort(ordered);

                _performances.Add(performance);
            }

            return _performances;
        }

        private double TimeSort(IEnumerable<int> items)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var sortedItems = _sort.SortItems(items);
            sw.Stop();

            return sw.Elapsed.TotalMilliseconds;
        }
    }
}
