using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitSignalHandler.BlockFuncs;
using BitSignalHandler.Models;

namespace PeriodSearch
{
    class PeriodSearcher
    {
        private BitArray _bitArray;
        private const int _defaultMaxPeriodSearchLength = 5000;
        private int _maxPeriodSearchLength;

        public PeriodSearcher(BitArray array) : this(array, _defaultMaxPeriodSearchLength) { }

   
        public PeriodSearcher(BitArray array, int maxPeriodSearchLength)
        {
            _bitArray = array;
            _maxPeriodSearchLength = maxPeriodSearchLength;
        }

        public bool TryToFindPeriod(out IEnumerable<int> supposedPeriods)
        {
            Dictionary<int, float[]> weightsToMaxWeight = new Dictionary<int, float[]>();
            int dictionaryLength = _bitArray.Length > _maxPeriodSearchLength ? _maxPeriodSearchLength : _bitArray.Length;

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;

            Parallel.For(1, dictionaryLength, parallelOptions, (int currentPeriodLength) =>
            {
                weightsToMaxWeight[currentPeriodLength] = ColumnsWeightToMaxWeightCounter.Count(_bitArray, currentPeriodLength);
            });

            supposedPeriods = (from periodWeightsToMaxWeight in weightsToMaxWeight
                                  from value in periodWeightsToMaxWeight.Value
                                  where value < 0.1f || value > 0.9f 
                                  select periodWeightsToMaxWeight.Key).Distinct();

            return supposedPeriods != null;
        }
    }
}
