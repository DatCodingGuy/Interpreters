using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniStringFuck_Interpreter
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
                if (c == '+')
                {
                    if (cell == 255)
                    {
                        cell = 0;
                    }
                    else
                    {
                        cell++;
                    }
                }
                else if (c == '.')
                {
                    Console.Write((char)cell);
                }
            }

            Console.ReadLine();
        }
    }
}
