using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacker_Interpreter
{
    class Scanner
    {
        static List<int> Tokens;
        static List<Block> blocks;
        
        public Scanner(string code)
        {
            Tokens = new List<int>();
            code = code.Replace(((char)13).ToString(), "");
            blocks = new List<Block>();
            Stack<Block> blockstack = new Stack<Block>();

            foreach (char c in code)
            {
                if (char.IsDigit(c))
                {
                    int i = (int)Char.GetNumericValue(c);
                    if (i == 0)
                    {
                        Tokens.Add(Opcodes.push0);
                    }
                    else if (i == 1)
                    {
                        Tokens.Add(Opcodes.push1);
                    }
                    else if (i == 2)
                    {
                        Tokens.Add(Opcodes.push2);
                    }
                    else if (i == 3)
                    {
                        Tokens.Add(Opcodes.push3);
                    }
                    else if (i == 4)
                    {
                        Tokens.Add(Opcodes.push4);
                    }
                    else if (i == 5)
                    {
                        Tokens.Add(Opcodes.push5);
                    }
                    else if (i == 6)
                    {
                        Tokens.Add(Opcodes.push6);
                    }
                    else if (i == 7)
                    {
                        Tokens.Add(Opcodes.push7);
                    }
                    else if (i == 8)
                    {
                        Tokens.Add(Opcodes.push8);
                    }
                    else if (i == 9)
                    {
                        Tokens.Add(Opcodes.push9);
                    }
                }
                else if (c == '$')
                {
                    Tokens.Add(Opcodes.pop);
                }
                else if (c == ':')
                {
                    Tokens.Add(Opcodes.duplicate);
                }
                else if (c == '_')
                {
                    Tokens.Add(Opcodes.swap);
                }
                else if (c == 'i')
                {
                    Tokens.Add(Opcodes.inc);
                }
                else if (c == 'd')
                {
                    Tokens.Add(Opcodes.dec);
                }
                else if (c == '+')
                {
                    Tokens.Add(Opcodes.add);
                }
                else if (c == '-')
                {
                    Tokens.Add(Opcodes.sub);
                }
                else if (c == '*')
                {
                    Tokens.Add(Opcodes.mul);
                }
                else if (c == '/')
                {
                    Tokens.Add(Opcodes.div);
                }
                else if (c == '^')
                {
                    Tokens.Add(Opcodes.square);
                }
                else if (c == '>')
                {
                    Tokens.Add(Opcodes.pte);
                }
                else if (c == '<')
                {
                    Tokens.Add(Opcodes.ptm);
                }
                else if (c == '}')
                {
                    Tokens.Add(Opcodes.pste);
                }
                else if (c == '{')
                {
                    Tokens.Add(Opcodes.pstm);
                }
                else if (c == '&')
                {
                    Tokens.Add(Opcodes.ini);
                }
                else if (c == ',')
                {
                    Tokens.Add(Opcodes.ina);
                }
                else if (c == '%')
                {
                    Tokens.Add(Opcodes.oui);
                }
                else if (c == '.')
                {
                    Tokens.Add(Opcodes.oua);
                }
                else if (c == '[')
                {
                    Tokens.Add(Opcodes.loop);
                }
                else if (c == ']')
                {
                    Tokens.Add(Opcodes.endloop);
                }
                else if (c == '(')
                {
                    Tokens.Add(Opcodes.startif);
                }
                else if (c == ')')
                {
                    Tokens.Add(Opcodes.endif);
                }
                else if (c == '=')
                {
                    Tokens.Add(Opcodes.cmp);
                }
                else if (c == 'e')
                {
                    Tokens.Add(Opcodes.execute);
                }
                else if (c == '!')
                {
                    Tokens.Add(Opcodes.end);
                }
                else if (c == '?')
                {
                    Tokens.Add(Opcodes.repeat);
                }
                else if (c == 'h')
                {
                    Tokens.Add(Opcodes.halt);
                }
                else if (c == '#')
                {
                    Tokens.Add(Opcodes.jump);
                }
                else if (c == '|')
                {
                    Tokens.Add(Opcodes.reverse);
                }
                else if (c == 'f')
                {
                    Tokens.Add(Opcodes.flip);
                }
            }
        }

        public List<int> GetTokens()
        {
            return Tokens;
        }

        public List<Block> GetBlocks()
        {
            return blocks;
        }
    }
}
