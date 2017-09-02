using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Brainfuck_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(args[0]);
            string code = sr.ReadToEnd();

            Scanner scanner = new Scanner(code);
            List<byte> tokens = scanner.GetTokens();
            TokenList list = new TokenList(tokens);
            List<Block> blocks = scanner.GetBlocks();

            Runtime runtime = new Runtime(list, blocks);
            
            while (true) { }
        }
    }
}
