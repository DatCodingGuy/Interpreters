using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Deadfish_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(args[0]);
            string code = sr.ReadToEnd();
            code = code.Replace(((char)13).ToString(), "");

            int cell = 0;

            foreach (char c in code)
            {
                if (c == 'i')
                {
                    cell++;
                }
                else if (c == 'd')
                {
                    cell--;
                }
                else if (c == 's')
                {
                    int i = cell * cell;
                    cell = i;
                }
                else if (c == 'o')
                {
                    Console.Write(cell);
                }

                if (cell == -1 || cell == 256)
                {
                    cell = 0;
                }
            }

            Console.ReadLine();
        }
    }
}