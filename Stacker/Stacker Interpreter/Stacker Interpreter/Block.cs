using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacker_Interpreter
{
    class Block
    {
        public int start_block;
        public int end_block;

        public Block(int start)
        {
            start_block = start;
            end_block = 0;
        }
    }
}
