using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BitSignalHandler.Models
{
    class BitSignalModel : IEnumerable
    {
        private BitArray _signalBits;

        public bool this[int index]
        {
            get => _signalBits[index];
            set => _signalBits[index] = value;
        }

        public bool At(int index) => _signalBits[index];

        public BitSignalModel(BitArray bitArray)
        {
            _signalBits = bitArray;
        }
        
        public IEnumerator GetEnumerator() => _signalBits.GetEnumerator();






    }
}
