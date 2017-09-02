using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_Interpreter
{
    class Runtime
    {
        static TokenList Tokens;
        static List<Block> Blocks;
        static Block current_block;
        static Stack<Block> blockstack;
        static int tape_pos;

        public Runtime(TokenList tokens, List<Block> blocks)
        {
            Tokens = tokens;
            Blocks = blocks;
            current_block = null;
            blockstack = new Stack<Block>();
            int[] tape = new int[30000];
            tape_pos = 0;

            byte opcode = 0;

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

                if (opcode == Opcodes.move_right)
                {
                    if (tape_pos == 30000)
                    {
                        ThrowError("(move_right) Exceeding boundaries of tape");
                    }
                    else
                    {
                        tape_pos++;
                    }
                }
                else if (opcode == Opcodes.move_left)
                {
                    if (tape_pos == 0)
                    {
                        ThrowError("(move_left) Can't move to a negative tape position");
                    }
                    else
                    {
                        tape_pos--;
                    }
                }
                else if (opcode == Opcodes.inc)
                {
                    if (tape_pos <= 30000)
                    {
                        tape[tape_pos]++;
                    }
                }
                else if (opcode == Opcodes.dec)
                {
                    if (tape_pos <= 30000)
                    {
                        tape[tape_pos]--;
                    }
                }
                else if (opcode == Opcodes.output)
                {
                    Console.Write((char)tape[tape_pos]);
                }
                else if (opcode == Opcodes.input)
                {
                    ConsoleKeyInfo c = Console.ReadKey();
                    char key = c.KeyChar;
                    tape[tape_pos] = (int)key;
                }
                else if (opcode == Opcodes.open)
                {
                    byte number = Tokens.GetToken();
                    Block b = GetBlock(number);

                    if (tape[tape_pos] == 0)
                    {
                        Tokens.pos = b.end_block;
                    }
                    else
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
                }
                else if (opcode == Opcodes.close)
                {
                    if (tape[tape_pos] != 0)
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
            }
        }

        static void ThrowError(string error)
        {
            Console.WriteLine("Error: " + error);
            while (true) { }
        }

        static Block GetBlock(byte block_number)
        {
            Block ret = null;

            foreach (Block b in Blocks)
            {
                if (b.block_number == block_number)
                {
                    ret = b;
                }
            }

            return ret;
        }
    }
}
