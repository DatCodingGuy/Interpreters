using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Deadfish_2_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(args[0]);
            string code = sr.ReadToEnd();
            code = code.Replace(((char)13).ToString(), "");

            int a = 0;
            string b = "";

            foreach (char c in code)
            {
                if (c == 'i')
                {
                    a++;
                }
                else if (c == 'd')
                {
                    a--;
                }
                else if (c == 's')
                {
                    a *= a;
                }
                else if (c == 'o')
                {
                    Console.Write(a);
                }
                else if (c == 'O')
                {
                    Console.Write(b);
                }
                else if (c == 'c')
                {
                    Console.Write((char)a);
                }
                else if (c == 'n')
                {
                    a = 0;
                }
                else if (c == 'r')
                {
                    b = Console.ReadLine();
                }
                else if (c == 'h')
                {
                    while (true) { }
                }
            }
        }
    }
}
