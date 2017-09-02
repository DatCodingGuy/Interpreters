using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fishstacks_Interpreter;

namespace Fishstacks_Interpreter
{
    class Program
    {
        static FS stack;

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(args[0]);
            string code = sr.ReadToEnd();
            code = code.Replace(((char)13).ToString(), "");

            stack = new FS();

            foreach (char c in code)
            {
                if (c == 'i')
                {
                    stack.Inc();
                }
                else if (c == 'd')
                {
                    stack.Dec();
                }
                else if (c == 'p')
                {
                    stack.Push(0);
                }
                else if (c == 's')
                {
                    stack.Square();
                }
            }

            Console.ReadLine();
        }
    }

    class FS
    {
        static List<int> stack;

        public FS()
        {
            stack = new List<int>();
        }

        public void Push(int data)
        {
            if (stack.Count == 4)
            {
                int i = PopBottom();
                Console.Write((char)i);
                stack.Add(data);
            }
            else
            {
                stack.Add(data);
            }
        }

        public int PopTop()
        {
            int count = stack.Count();
            int ret = stack[count - 1];
            stack.RemoveAt(count - 1);
            return ret;
        }

        public int PopBottom()
        {
            int ret = stack[0];
            stack.RemoveAt(0);
            return ret;
        }

        public void Inc()
        {
            int count = stack.Count();
            stack[count - 1]++;
        }

        public void Dec()
        {
            int count = stack.Count();
            stack[count - 1]--;
        }

        public void Square()
        {
            int val = PopTop();
            int data = val * val;
            Push(data);
        }

        public void Wrap()
        {
            int count = stack.Count();
            if (stack[count - 1] == -1 || stack[count - 1] == 256)
            {
                stack[count - 1] = 0;
            }
        }

        public List<int> GetStack()
        {
            return stack;
        }
    }
}
