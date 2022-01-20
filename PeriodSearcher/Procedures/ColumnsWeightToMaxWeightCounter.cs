using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BitSignalHandler.BlockFuncs
{
    static class ColumnsWeightToMaxWeightCounter
    {
        static public float[] Count(BitArray array, int columnsToSum)
        {
            float[] weightsToMaxWeight = new float[columnsToSum];
            int rowsCount = array.Length / columnsToSum;

            for (int i = 0; i < columnsToSum; i++)
            {
                for (int j = 0; j < rowsCount; j++)
                {
                    weightsToMaxWeight[i] += array[columnsToSum * j + i] ? 1 : 0;
                }
                weightsToMaxWeight[i] /= rowsCount;
            }
            return weightsToMaxWeight;
        }
    }
}
