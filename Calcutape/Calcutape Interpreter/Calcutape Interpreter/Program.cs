using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Calcutape_Interpreter;

namespace Calcutape_Interpreter
{
    class Program
    {
        static List<int> tokens;
        static int pos;
        static int dir;

        static void Main(string[] args)
        {
            tokens = new List<int>();
            pos = 0;
            dir = 0;

            StreamReader sr = new StreamReader(args[0]);
            string code = sr.ReadToEnd();
            code = code.Replace(((char)13).ToString(), "");

            Scanner(code);
            Execute();
        }

        static void Scanner(string code)
        {
            bool incomment = false;

            foreach (char c in code)
            {
                if (!incomment)
                {
                    if (char.IsDigit(c))
                    {
                        int i = (int)Char.GetNumericValue(c);
                        tokens.Add(Opcodes.push);
                        tokens.Add(i);
                    }
                    else if (c == '+')
                    {
                        tokens.Add(Opcodes.add);
                    }
                    else if (c == '-')
                    {
                        tokens.Add(Opcodes.sub);
                    }
                    else if (c == '*')
                    {
                        tokens.Add(Opcodes.mul);
                    }
                    else if (c == '/')
                    {
                        tokens.Add(Opcodes.div);
                    }
                    else if (c == ':')
                    {
                        tokens.Add(Opcodes.rand);
                    }
                    else if (c == '%')
                    {
                        tokens.Add(Opcodes.out_int);
                    }
                    else if (c == '@')
                    {
                        tokens.Add(Opcodes.out_char);
                    }
                    else if (c == '|')
                    {
                        tokens.Add(Opcodes.swap);
                    }
                    else if (c == '_')
                    {
                        tokens.Add(Opcodes.duplicate);
                    }
                    else if (c == '&')
                    {
                        tokens.Add(Opcodes.push_n);
                    }
                    else if (c == '$')
                    {
                        tokens.Add(Opcodes.pop);
                    }
                    else if (c == '^')
                    {
                        tokens.Add(Opcodes.wait);
                    }
                    else if (c == '=')
                    {
                        tokens.Add(Opcodes.clear);
                    }
                    else if (c == '?')
                    {
                        tokens.Add(Opcodes.exit);
                    }
                    else if (c == '#')
                    {
                        tokens.Add(Opcodes.exec);
                    }
                    else if (c == 'V')
                    {
                        tokens.Add(Opcodes.read);
                    }
                    else if (c == '(')
                    {
                        incomment = true;
                    }
                }
                else
                {
                    if (c == ')')
                    {
                        incomment = false;
                    }
                }
            }
        }

        static void Execute()
        {
            CalcuStack stack = new CalcuStack();
            int op = 0;
            bool running = true;

            while (running)
            {
                try
                {
                    op = GetToken();
                }
                catch
                {
                    running = false;
                }

                if (op == Opcodes.push)
                {
                    int i = GetToken();
                    stack.Push(i);
                }
                else if (op == Opcodes.add)
                {
                    stack.Add();
                }
                else if (op == Opcodes.sub)
                {
                    stack.Sub();
                }
                else if (op == Opcodes.mul)
                {
                    stack.Mul();
                }
                else if (op == Opcodes.div)
                {
                    stack.Div();
                }
                else if (op == Opcodes.rand)
                {
                    Random rand = new Random();
                    int r = rand.Next(1, 999);
                    stack.Push(r);
                }
                else if (op == Opcodes.out_int)
                {
                    Console.Write(stack.Pop());
                }
                else if (op == Opcodes.out_char)
                {
                    Console.Write((char)stack.Pop());
                }
                else if (op == Opcodes.swap)
                {
                    stack.Swap();
                }
                else if (op == Opcodes.duplicate)
                {
                    stack.Duplicate();
                }
                else if (op == Opcodes.push_n)
                {
                    stack.Push_N();
                }
                else if (op == Opcodes.pop)
                {
                    stack.Pop();
                }
                else if (op == Opcodes.wait)
                {
                    stack.Wait();
                }
                else if (op == Opcodes.clear)
                {
                    Console.Clear();
                }
                else if (op == Opcodes.exit)
                {
                    running = false;
                }
                else if (op == Opcodes.exec)
                {
                    int dim = stack.Peek();
                    if (dim == 0)
                    {
                        if (dir == 0)
                        {
                            dir = 1;
                        }
                        else
                        {
                            dir = 0;
                        }
                    }
                    if (dim > 0)
                    {
                        pos += dim;
                    }
                }
                else if (op == Opcodes.read)
                {
                    ConsoleKeyInfo c = Console.ReadKey(true);
                    char key = c.KeyChar;
                    stack.Push((int)key);
                }
            }
        }

        static int GetToken()
        {
            int ret = 0;

            if (dir == 0)
            {
                ret = tokens[pos];
                pos++;
            }
            else if (dir == 1)
            {
                if (pos == 0)
                {
                    ret = tokens[pos];
                    pos++;
                    dir = 0;
                }
            }

            return ret;
        }

        static int Peek()
        {
            return tokens[pos];
        }
    }
}
