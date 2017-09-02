using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_Interpreter
{
    class Block
    {
        public int start_block;
        public int end_block;
        public byte block_number;

        public Block(int start, byte b)
        {
            start_block = start;
            end_block = 0;
            block_number = b;
        }
    }
}
