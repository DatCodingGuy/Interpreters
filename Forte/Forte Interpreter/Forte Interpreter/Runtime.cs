using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forte_Interpreter
{
    class Runtime
    {
        static List<Line> Lines;
        static List<LetValue> Values;
        static Stack<int> MathStack;

        public Runtime(List<Line> lines)
        {
            Lines = lines;
            Values = new List<LetValue>();
            MathStack = new Stack<int>();

            int lastline = 0;

            foreach (Line l in Lines)
            {
                if (l.Number >= lastline)
                {
                    lastline = l.Number;
                }
            }

            int linepos = 1;

            while (linepos <= lastline)
            {
                ExecuteLine(CheckValue(linepos));

                linepos++;
            }
        }

        static void ExecuteLine(int number)
        {
            foreach (Line line in Lines)
            {
                if (line.Number == number)
                {
                    foreach (Stmt s in line.Statements)
                    {
                        ExecuteStatement(s);
                    }
                }
            }
        }

        static void ExecuteStatement(Stmt stmt)
        {
            if (stmt is Let)
            {
                Let op = (Let)stmt;
                UpdateValues(EvalExpr(op.Expr1), EvalExpr(op.Expr2));
            }
            else if (stmt is Print)
            {
                Print op = (Print)stmt;
                if (op.Newline)
                {
                    Console.WriteLine(EvalExpr(op.Expr));
                }
                else
                {
                    Console.Write(EvalExpr(op.Expr));
                }
            }
            else if (stmt is PrintString)
            {
                PrintString op = (PrintString)stmt;
                string s = op.String.Substring(1, op.String.Length - 2);
                if (op.Newline)
                {
                    Console.WriteLine(s);
                }
                else
                {
                    Console.Write(s);
                }
            }
            else if (stmt is Input)
            {
                Input op = (Input)stmt;
            }
            else if (stmt is Get)
            {
                Get op = (Get)stmt;
            }
            else if (stmt is Put)
            {
                Put op = (Put)stmt;
            }
        }

        static int EvalExpr(Expr expr)
        {
            int ret = 0;

            if (expr is Constant)
            {
                Constant op = (Constant)expr;
                ret = op.Value;
            }
            else if (expr is MathExpr)
            {
                MathExpr op = (MathExpr)expr;
                int dim1 = CheckValue(EvalExpr(op.Expr1));
                int dim2 = CheckValue(EvalExpr(op.Expr2));

                if (op.Operator == Symbol.add)
                {
                    ret = dim1 + dim2;

                }
                else if (op.Operator == Symbol.sub)
                {
                    ret = dim1 - dim2;
                }
                else if (op.Operator == Symbol.mul)
                {
                    ret = dim1 * dim2;
                }
                else if (op.Operator == Symbol.div)
                {
                    ret = dim1 / dim2;
                }
            }
            else if (expr is ParanExpr)
            {
                ParanExpr op = (ParanExpr)expr;
                ret = EvalExpr(op.Expr);
            }

            return CheckValue(ret);
        }

        static int CheckValue(int value)
        {
            bool changed = false;
            int ret = 0;

            foreach (LetValue v in Values)
            {
                if (v.initial_value == value)
                {
                    ret = v.current_value;
                    changed = true;
                }
            }

            if (!changed)
            {
                ret = value;
            }

            return ret;
        }

        static void UpdateValues(int v1, int v2)
        {
            bool found = false;

            foreach (LetValue v in Values)
            {
                if (v.initial_value == v1)
                {
                    found = true;
                    v.current_value = v2;
                }
                else if (v.current_value == v1)
                {
                    v.current_value = v2;
                }
            }

            if (!found)
            {
                LetValue value = new LetValue(v1, v2);
                Values.Add(value);
            }
        }
    }

    class LetValue
    {
        public int initial_value;
        public int current_value;

        public LetValue(int initial, int current)
        {
            initial_value = initial;
            current_value = current;
        }
    }
}
