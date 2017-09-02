using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Forte_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(args[0]);
            string code = sr.ReadToEnd();

            Lexer lexer = new Lexer();
            lexer.InputString = code;

            TokenList list = new TokenList(lexer);

            Parser parser = new Parser(list);

            Runtime runtime = new Runtime(parser.GetLines());

            while (true) { }
        }
    }
}
