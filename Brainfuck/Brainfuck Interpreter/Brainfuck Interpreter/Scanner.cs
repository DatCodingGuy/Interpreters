using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_Interpreter
{
    class Scanner
    {
        static List<byte> Tokens;
        static List<Block> Blocks;

        public Scanner(string code)
        {
            Tokens = new List<byte>();
            Blocks = new List<Block>();
            byte block_number = 0;
            Block current_block = null;
            Stack<Block> blockstack = new Stack<Block>();

            code = code.Replace(((char)13).ToString(), "");

            foreach (char c in code)
            {
                if (c == '>')
                {
                    Tokens.Add(Opcodes.move_right);
                }
                else if (c == '<')
                {
                    Tokens.Add(Opcodes.move_left);
                }
                else if (c == '+')
                {
                    Tokens.Add(Opcodes.inc);
                }
                else if (c == '-')
                {
                    Tokens.Add(Opcodes.dec);
                }
                else if (c == '.')
                {
                    Tokens.Add(Opcodes.output);
                }
                else if (c == ',')
                {
                    Tokens.Add(Opcodes.input);
                }
                else if (c == '[')
                {
                    Tokens.Add(Opcodes.open);
                    Tokens.Add(block_number);
                    Block b = new Block(Tokens.Count, block_number);
                    block_number++;

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
                else if (c == ']')
                {
                    Tokens.Add(Opcodes.close);
                    current_block.end_block = Tokens.Count;

                    if (blockstack.Count > 0)
                    {
                        Blocks.Add(current_block);
                        current_block = blockstack.Pop();
                    }
                    else
                    {
                        Blocks.Add(current_block);
                        current_block = null;
                    }
                }
            }
        }

        public List<byte> GetTokens()
        {
            return Tokens;
        }

        public List<Block> GetBlocks()
        {
            return Blocks;
        }
    }
}
