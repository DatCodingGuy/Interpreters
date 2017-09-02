using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_Interpreter
{
    class TokenList
    {
        static List<byte> Tokens;
        public int pos = 0;

        public TokenList(List<byte> tokens)
        {
            Tokens = tokens;
        }

        public byte GetToken()
        {
            byte ret = Tokens[pos];
            pos++;
            return ret;
        }
    }
}
