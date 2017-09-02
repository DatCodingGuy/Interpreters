using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcutape_Interpreter
{
    class Opcodes
    {
        public static readonly int push = 0;
        public static readonly int add = 1;
        public static readonly int sub = 2;
        public static readonly int mul = 3;
        public static readonly int div = 4;
        public static readonly int rand = 5;
        public static readonly int out_int = 6;
        public static readonly int out_char = 7;
        public static readonly int swap = 8;
        public static readonly int duplicate = 9;
        public static readonly int push_n = 10;
        public static readonly int pop = 11;
        public static readonly int wait = 12;
        public static readonly int clear = 13;
        public static readonly int exit = 14;
        public static readonly int exec = 15;
        public static readonly int read = 17;
    }
}
