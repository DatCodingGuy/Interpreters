using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_Interpreter
{
    class Opcodes
    {
        public static readonly byte move_right = 0;
        public static readonly byte move_left = 1;
        public static readonly byte inc = 2;
        public static readonly byte dec = 3;
        public static readonly byte output = 4;
        public static readonly byte input = 5;
        public static readonly byte open = 6;
        public static readonly byte close = 7;
    }
}
