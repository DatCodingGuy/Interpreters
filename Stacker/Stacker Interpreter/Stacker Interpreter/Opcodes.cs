using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacker_Interpreter
{
    class Opcodes
    {
        public static readonly int push0 = 0; //0
        public static readonly int push1 = 1; //1
        public static readonly int push2 = 2; //2
        public static readonly int push3 = 3; //3
        public static readonly int push4 = 4; //4
        public static readonly int push5 = 5; //5
        public static readonly int push6 = 6; //6
        public static readonly int push7 = 7; //7
        public static readonly int push8 = 8; //8
        public static readonly int push9 = 9; //9
        public static readonly int pop = 10; //$
        public static readonly int duplicate = 11; //:
        public static readonly int swap = 12; //_
        public static readonly int inc = 13; //i
        public static readonly int dec = 14; //d
        public static readonly int add = 15; //+
        public static readonly int sub = 16; //-
        public static readonly int mul = 17; //*
        public static readonly int div = 18; //
        public static readonly int square = 19; //^
        public static readonly int pte = 20; //>
        public static readonly int ptm = 21; //<
        public static readonly int pste = 22; //}
        public static readonly int pstm = 23; //{
        public static readonly int ini = 24; //&
        public static readonly int ina = 25; //,
        public static readonly int oui = 26; //%
        public static readonly int oua = 27; //.
        public static readonly int loop = 28; //[
        public static readonly int endloop = 29; //]
        public static readonly int startif = 30; //(
        public static readonly int endif = 31; //)
        public static readonly int cmp = 32; //=
        public static readonly int execute = 33; //e
        public static readonly int end = 34; //!
        public static readonly int repeat = 35; //?
        public static readonly int halt = 38; //h
        public static readonly int jump = 39; //#
        public static readonly int reverse = 40; //|
        public static readonly int flip = 41; //f
    }
}
