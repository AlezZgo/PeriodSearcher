using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitSignalHandlerExp.Procedures
{
    static class HightWeightToMaxWeightGetter
    {
        private const float _errorRate = 0.15f;

        public static List<float> Get(int[] weights,int maxWeight)
        {
            int lowerBound = (int)(maxWeight * _errorRate);
            int upperBound = (int)(maxWeight - lowerBound);
            return new List<float>();
        }
    }
}
