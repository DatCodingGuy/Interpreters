using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacker_Interpreter
{
    class TokenList
    {
        public List<int> Tokens;
        public int pos = 0;
        public int dir = 0;

        public TokenList(List<int> tokens)
        {
            Tokens = tokens;
        }

        public int GetToken()
        {
            int ret = Tokens[pos];

            if (dir == 0)
            {
                pos++;
            }
            else if (dir == 1)
            {
                pos--;
            }
            return ret;
        }

        public int Peek()
        {
            return Tokens[pos];
        }

        public void Insert(int index, int op)
        {
            Tokens.Insert(index, op);
        }
    }
}
