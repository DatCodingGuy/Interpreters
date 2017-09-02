using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacker_Interpreter
{
    class Runtime
    {
        static TokenList Tokens;
        static List<Block> Blocks;
        static Block current_block;
        static Stack<Block> blockstack;
        static Stack<int> mainstack;
        static Stack<int> extrastack;
        static bool flag;

        public Runtime(TokenList tokens, List<Block> blocks)
        {
            Tokens = tokens;
            Blocks = blocks;
            current_block = null;
            blockstack = new Stack<Block>();
            mainstack = new Stack<int>();
            extrastack = new Stack<int>();
            flag = true;

            ExecuteTokens();
        }

        static void ExecuteTokens()
        {
            int opcode = 0;

            while (true)
            {
                try
                {
                    opcode = Tokens.GetToken();
                }
                catch
                {
                    break;
                }

                int exec = ExecuteCommand(opcode);
                if (exec == 1)
                {
                    break;
                }
            }
        }

        static int ExecuteCommand(int opcode)
        {
            int ret = 0;

            if (opcode == Opcodes.push0)
            {
                mainstack.Push(0);
            }
            else if (opcode == Opcodes.push1)
            {
                mainstack.Push(1);
            }
            else if (opcode == Opcodes.push2)
            {
                mainstack.Push(2);
            }
            else if (opcode == Opcodes.push3)
            {
                mainstack.Push(3);
            }
            else if (opcode == Opcodes.push4)
            {
                mainstack.Push(4);
            }
            else if (opcode == Opcodes.push5)
            {
                mainstack.Push(5);
            }
            else if (opcode == Opcodes.push6)
            {
                mainstack.Push(6);
            }
            else if (opcode == Opcodes.push7)
            {
                mainstack.Push(7);
            }
            else if (opcode == Opcodes.push8)
            {
                mainstack.Push(8);
            }
            else if (opcode == Opcodes.push9)
            {
                mainstack.Push(9);
            }
            else if (opcode == Opcodes.pop)
            {
                mainstack.Pop();
            }
            else if (opcode == Opcodes.duplicate)
            {
                if (mainstack.Count > 0)
                {
                    int op = mainstack.Pop();
                    mainstack.Push(op);
                    mainstack.Push(op);
                }
                else
                {
                    ThrowError("(duplicate) Main Stack Empty");
                }
            }
            else if (opcode == Opcodes.swap)
            {
                if (mainstack.Count > 1)
                {
                    int op1 = mainstack.Pop();
                    int op2 = mainstack.Pop();
                    mainstack.Push(op1);
                    mainstack.Push(op2);
                }
                else
                {
                    ThrowError("(swap) Not Enough Values In Main Stack");
                }
            }
            else if (opcode == Opcodes.inc)
            {
                if (mainstack.Count > 0)
                {
                    int op = mainstack.Pop();
                    op++;
                    mainstack.Push(op);
                }
                else
                {
                    ThrowError("(inc) Stack Main Empty");
                }
            }
            else if (opcode == Opcodes.dec)
            {
                if (mainstack.Count > 0)
                {
                    int op = mainstack.Pop();
                    op--;
                    mainstack.Push(op);
                }
                else
                {
                    ThrowError("(dec) Stack Main Empty");
                }
            }
            else if (opcode == Opcodes.add)
            {
                if (mainstack.Count > 1)
                {
                    int op1 = mainstack.Pop();
                    int op2 = mainstack.Pop();
                    int op = op1 + op2;
                    mainstack.Push(op);
                }
                else
                {
                    ThrowError("(add) Not Enough Values In Main Stack");
                }
            }
            else if (opcode == Opcodes.sub)
            {
                if (mainstack.Count > 1)
                {
                    int op1 = mainstack.Pop();
                    int op2 = mainstack.Pop();
                    int op = op1 - op2;
                    mainstack.Push(op);
                }
                else
                {
                    ThrowError("(sub) Not Enough Values In Main Stack");
                }
            }
            else if (opcode == Opcodes.mul)
            {
                if (mainstack.Count > 1)
                {
                    int op1 = mainstack.Pop();
                    int op2 = mainstack.Pop();
                    int op = op1 * op2;
                    mainstack.Push(op);
                }
                else
                {
                    ThrowError("(mul) Not Enough Values In Main Stack");
                }
            }
            else if (opcode == Opcodes.div)
            {
                if (mainstack.Count > 1)
                {
                    int op1 = mainstack.Pop();
                    int op2 = mainstack.Pop();
                    int op = op1 / op2;
                    mainstack.Push(op);
                }
                else
                {
                    ThrowError("(div) Not Enough Values In Main Stack");
                }
            }
            else if (opcode == Opcodes.square)
            {
                if (mainstack.Count > 0)
                {
                    int op = mainstack.Pop();
                    int dim = op * op;
                    mainstack.Push(dim);
                }
                else
                {
                    ThrowError("(square) Main Stack Empty");
                }
            }
            else if (opcode == Opcodes.pte)
            {
                if (mainstack.Count > 0)
                {
                    int op = mainstack.Pop();
                    extrastack.Push(op);
                }
                else
                {
                    ThrowError("(pte) Stack Main Empty");
                }
            }
            else if (opcode == Opcodes.ptm)
            {
                if (extrastack.Count > 0)
                {
                    int op = extrastack.Pop();
                    mainstack.Push(op);
                }
                else
                {
                    ThrowError("(ptm) Extra Stack Empty");
                }
            }
            else if (opcode == Opcodes.pste)
            {
                int count = mainstack.Pop();
                if (mainstack.Count >= count)
                {
                    int i = 0;
                    List<int> temp = new List<int>();
                    while (i < count)
                    {
                        temp.Add(mainstack.Pop());
                        i++;
                    }
                    temp.Reverse();
                    foreach (int op in temp)
                    {
                        extrastack.Push(op);
                    }
                }
                else
                {
                    ThrowError("(pste) Not Enough Values In Main Stack");
                }
            }
            else if (opcode == Opcodes.pstm)
            {
                int count = mainstack.Pop();
                if (extrastack.Count >= count)
                {
                    int i = 0;
                    List<int> temp = new List<int>();
                    while (i < count)
                    {
                        temp.Add(extrastack.Pop());
                        i++;
                    }
                    temp.Reverse();
                    foreach (int op in temp)
                    {
                        mainstack.Push(op);
                    }
                }
                else
                {
                    ThrowError("(pstm) Not Enough Values In Extra Stack");
                }
            }
            else if (opcode == Opcodes.ini)
            {
                ConsoleKeyInfo c = new ConsoleKeyInfo();
                char key = ' ';
                string temp = "";
                int i = 0;
                while (true)
                {
                    c = Console.ReadKey(true);
                    key = c.KeyChar;
                    if (!char.IsControl(key))
                    {
                        temp += key;
                    }
                    else
                    {
                        break;
                    }
                }
                try
                {
                    i = Convert.ToInt32(temp);
                }
                catch
                {
                    ret = 1;
                }

                mainstack.Push(i);
            }
            else if (opcode == Opcodes.ina)
            {
                ConsoleKeyInfo c = Console.ReadKey(true);
                char key = c.KeyChar;
                mainstack.Push((int)key);
            }
            else if (opcode == Opcodes.oui)
            {
                if (mainstack.Count > 0)
                {
                    Console.Write(mainstack.Pop());
                }
                else
                {
                    ThrowError("Error: Main Stack Empty");
                }
            }
            else if (opcode == Opcodes.oua)
            {
                if (mainstack.Count > 0)
                {
                    Console.Write((char)mainstack.Pop());
                }
                else
                {
                    ThrowError("Error: Main Stack Empty");
                }
            }
            else if (opcode == Opcodes.loop)
            {
                Block b = new Block(Tokens.pos);
                if (flag)
                {
                    if (current_block == null)
                    {
                        current_block = b;
                    }
                    else
                    {
                        blockstack.Push(current_block);
                        current_block = b;
                    }
                }
                else
                {
                    FindEndBlock();
                }
            }
            else if (opcode == Opcodes.endloop)
            {
                if (!flag)
                {
                    Tokens.pos = current_block.start_block;
                }
                else
                {
                    if (blockstack.Count > 0)
                    {
                        current_block = blockstack.Pop();
                    }
                    else
                    {
                        current_block = null;
                    }
                }
            }
            else if (opcode == Opcodes.startif)
            {
                Block b = new Block(Tokens.pos);
                if (flag)
                {
                    if (current_block == null)
                    {
                        current_block = b;
                    }
                    else
                    {
                        blockstack.Push(current_block);
                        current_block = b;
                    }
                }
                else
                {
                    FindEndBlock();
                }
            }
            else if (opcode == Opcodes.endif)
            {
                if (blockstack.Count > 0)
                {
                    current_block = blockstack.Pop();
                }
                else
                {
                    current_block = null;
                }
            }
            else if (opcode == Opcodes.cmp)
            {
                if (mainstack.Count > 0)
                {
                    int dim = mainstack.Pop();
                    int op1 = mainstack.Pop();
                    int op2 = mainstack.Pop();

                    if (dim == 0)
                    {
                        if (op1 == op2)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else if (dim == -1)
                    {
                        if (op1 < op2)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else if (dim == 1)
                    {
                        if (op1 > op2)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
                else
                {
                    ThrowError("(cmp) Not Enough Values In Main Stack");
                }
            }
            else if (opcode == Opcodes.execute)
            {
                if (mainstack.Count > 0)
                {
                    int op = mainstack.Pop();
                    ExecuteCommand(op);
                }
                else
                {
                    ThrowError("(execute) Main Stack Empty");
                }
            }
            else if (opcode == Opcodes.end)
            {
                ret = 1;
            }
            else if (opcode == Opcodes.repeat)
            {
                Tokens.pos = 0;
            }
            else if (opcode == Opcodes.halt)
            {
                while (true) { }
            }
            else if (opcode == Opcodes.jump)
            {
                if (flag)
                {
                    Tokens.pos++;
                }
            }
            else if (opcode == Opcodes.reverse)
            {
                if (Tokens.dir == 0)
                {
                    Tokens.dir = 1;
                    Tokens.pos -= 2;
                }
                else if (Tokens.dir == 1)
                {
                    Tokens.dir = 0;
                    Tokens.pos += 2;
                }
            }
            else if (opcode == Opcodes.flip)
            {
                if (flag)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }

            return ret;
        }

        static void ThrowError(string error)
        {
            Console.WriteLine("Error: " + error);
            while (true) { }
        }

        static void Insert(int index, int op)
        {
            List<int> temp = new List<int>();
            int i = 0;

            if (i == index)
            {
                temp.Add(op);
            }
            else
            {
                temp.Add(Tokens.Tokens[i]);
                i++;
            }

            Tokens.Tokens = temp;
        }

        static void FindEndBlock()
        {
            int opcode = 0;
            int find = 0;

            while (true)
            {
                opcode = Tokens.GetToken();

                if (opcode == Opcodes.loop)
                {
                    find++;
                }
                else if (opcode == Opcodes.endloop)
                {
                    if (find == 0)
                    {
                        break;
                    }
                }
                else if (opcode == Opcodes.startif)
                {
                    find++;
                }
                else if (opcode == Opcodes.endif)
                {
                    if (find == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}