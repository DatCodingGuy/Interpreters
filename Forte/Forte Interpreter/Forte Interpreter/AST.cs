using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forte_Interpreter
{
    class Stmt { }

    class Expr { }

    class Line
    {
        public int Number;
        public List<Stmt> Statements;

        public Line(int number)
        {
            Number = number;
            Statements = new List<Stmt>();
        }
    }

    class Let : Stmt
    {
        public Expr Expr1;
        public Expr Expr2;

        public Let(Expr expr1, Expr expr2)
        {
            Expr1 = expr1;
            Expr2 = expr2;
        }
    }

    class Print : Stmt
    {
        public Expr Expr;
        public bool Newline;

        public Print(Expr expr, bool newline)
        {
            Expr = expr;
            Newline = newline;
        }
    }

    class PrintString : Stmt
    {
        public string String;
        public bool Newline;

        public PrintString(string s, bool newline)
        {
            String = s;
            Newline = newline;
        }
    }

    class Input : Stmt
    {
        public Expr Expr;

        public Input(Expr expr)
        {
            Expr = expr;
        }
    }

    class Get : Stmt
    {
        public Expr Expr;

        public Get(Expr expr)
        {
            Expr = expr;
        }
    }

    class Put : Stmt
    {
        public Expr Expr;

        public Put(Expr expr)
        {
            Expr = expr;
        }
    }

    class End : Stmt
    {

    }

    class Constant : Expr
    {
        public int Value;
        
        public Constant(int value)
        {
            Value = value;
        }
    }

    class MathExpr : Expr
    {
        public Expr Expr1;
        public Symbol Operator;
        public Expr Expr2;

        public MathExpr(Expr expr1, Symbol op, Expr expr2)
        {
            Expr1 = expr1;
            Operator = op;
            Expr2 = expr2;
        }
    }

    class ParanExpr : Expr
    {
        public Expr Expr;

        public ParanExpr(Expr expr)
        {
            Expr = expr;
        }
    }

    enum Symbol
    {
        add = 0,
        sub = 1,
        mul = 2,
        div = 3,
        equal = 4,
        left_paran = 5,
        right_paran = 6
    }
}
