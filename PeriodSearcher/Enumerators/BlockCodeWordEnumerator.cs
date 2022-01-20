using BitSignalHandlerExp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitSignalHandlerExp.Enumerators
{
    class BlockCodeWordEnumerator : IEnumerator<BlockCodeWordModel>
    {
        private BlockCodeWordModel[] _blockCodeWords;

        private int _position = -1;

        public BlockCodeWordEnumerator(BlockCodeWordModel[] blockCodeWords)
        {
            _blockCodeWords = blockCodeWords;
        }

        public BlockCodeWordModel Current
        {
            get
            {
                try
                {
                    return _blockCodeWords[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _blockCodeWords.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
