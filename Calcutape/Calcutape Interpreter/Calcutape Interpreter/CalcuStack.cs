using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* I know some people are wondering why I made my own stack, wouldn't it have been easier to use
 * the default stack class that C# comes with? Well, I thought about it and decided to make my
 * own stack due to the command that pops the top number (N) and pushes a copy of the Nth element
 * on the stack. I thought this would've been annoying to implement if I used the default Stack class
 * so I decided to write my own stack. 
 */

namespace Calcutape_Interpreter
{
    class CalcuStack
    {
        static List<int> stack;

        public CalcuStack()
        {
            stack = new List<int>();
        }

        public void Push(int data)
        {
            stack.Add(data);
        }

        public int Pop()
        {
            if (stack.Count > 0)
            {
                int count = stack.Count();
                int ret = stack[count - 1];
                stack.RemoveAt(count - 1);
                return ret;
            }
            else
            {
                return 0;
            }
        }

        public int Peek()
        {
            if (stack.Count > 0)
            {
                int count = stack.Count();
                return stack[count - 1];
            }
            else
            {
                return 0;
            }
        }

        public void Add()
        {
            int dim1 = Pop();
            int dim2 = Pop();
            Push(dim1 + dim2);
        }

        public void Sub()
        {
            int dim1 = Pop();
            int dim2 = Pop();
            Push(dim1 - dim2);
        }

        public void Mul()
        {
            int dim1 = Pop();
            int dim2 = Pop();
            Push(dim1 * dim2);
        }

        public void Div()
        {
            int dim1 = Pop();
            int dim2 = Pop();
            Push(dim1 / dim2);
        }

        public void Swap()
        {
            int dim1 = Pop();
            int dim2 = Pop();

            Push(dim1);
            Push(dim2);
        }

        public void Duplicate()
        {
            Push(Peek());
        }

        public void Push_N()
        {
            int i = Pop();
            Push(stack[stack.Count - i]);
        }

        public void Wait()
        {
            System.Threading.Thread.Sleep(Pop());
        }

        public List<int> GetStack()
        {
            return stack;
        }
    }
}
