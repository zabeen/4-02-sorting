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
        public double ElapsedMs { get; set; }
        public int SizeFactor { get; set; }
        public double TimeFactor { get; set; }
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

        public TimeTest(int seedValue, int minValue, int maxValue ,int count, IEnumerable<int> sizeIncrements, int baselineIndex)
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
            return string.Join("\n", _performances.OrderBy(p => p.ItemCount).Select(p => $"{p.ItemCount:N0} items, {p.ElapsedMs}ms; x{p.SizeFactor:N0} size => x{p.TimeFactor:N1} time").ToList());
        }

        public List<Performance> AssessSortPerformance()
        {
            foreach (var increment in _sizeIncrements)
            {
                Performance performance = new Performance() { ItemCount = _count * increment, SizeFactor = increment };
                var items = Generator.GenerateRandomNumbers(_seedValue, _minValue, _maxValue, performance.ItemCount);            
                performance.ElapsedMs = TimeSort(items);
                _performances.Add(performance);
            }

            var baselineTime = _performances[_baselineIndex].ElapsedMs;
            _performances.ForEach(p => p.TimeFactor = p.ElapsedMs/baselineTime);

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
