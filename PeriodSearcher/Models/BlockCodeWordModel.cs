using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitSignalHandlerExp.Models
{
    class BlockCodeWordModel : IEnumerable
    {
        private bool[,] _blockCodeWord;

        public bool this[int rowIndex, int ColumnIndex]
        {
            get => _blockCodeWord[rowIndex, ColumnIndex];
            set => _blockCodeWord[rowIndex, ColumnIndex] = value;
        }

        public BlockCodeWordModel(bool[,] blockCodeWord)
        {
            _blockCodeWord = blockCodeWord;
        }

        public IEnumerator GetEnumerator() => _blockCodeWord.GetEnumerator();

        
    }
}
