using BitSignalHandlerExp.Models;
using BitSignalHandlerExp.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BitSignalHandler.Models
{
    class BlockBitSignalModel : IEnumerable<BlockCodeWordModel>
    {
        BlockCodeWordModel[] _blockCodeWords;

        public BlockCodeWordModel this[int index]
        {
            get => _blockCodeWords[index]; 
            set => _blockCodeWords[index] = value;
        }

        public BlockCodeWordModel At(int index) => _blockCodeWords[index];

        public BlockBitSignalModel(BlockCodeWordModel[] blockCodeWords, int width, int height)
        {
            _blockCodeWords = blockCodeWords;
        }

        public IEnumerator<BlockCodeWordModel> GetEnumerator() => new BlockCodeWordEnumerator(_blockCodeWords);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
