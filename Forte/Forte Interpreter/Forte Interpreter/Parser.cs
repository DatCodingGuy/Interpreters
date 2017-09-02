using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forte_Interpreter
{
    class Parser
    {
        static TokenList Tokens;
        static Line current_line;
        static List<Line> Lines;

        public Parser(TokenList tokens)
        {
            Tokens = tokens;
            current_line = null;
            Token t = null;
            Lines = new List<Line>();

            while (true)
            {
                try
                {
                    t = Tokens.GetToken();
                }
                catch
                {
                    break;
                }

                if (current_line == null)
                {
                    if (t.TokenName.ToString() == "IntLiteral")
                    {
                        int number = Convert.ToInt32(t.TokenValue.ToString());
                        current_line = new Line(number);
                    }
                }
                else
                {
                    if (t.TokenName.ToString() == "Let")
                    {
                        Stmt op = ParseLet();
                        AddStmt(op);
                    }
                    else if (t.TokenName.ToString() == "Print")
                    {
                        Stmt op = ParsePrint();
                        AddStmt(op);
                    }
                    else if (t.TokenName.ToString() == "Input")
                    {
                        Stmt op = ParseInput();
                        AddStmt(op);
                    }
                    else if (t.TokenName.ToString() == "Get")
                    {
                        Stmt op = ParseGet();
                        AddStmt(op);
                    }
                    else if (t.TokenName.ToString() == "Put")
                    {
                        Stmt op = ParsePut();
                        AddStmt(op);
                    }
                    else if (t.TokenName.ToString() == "End")
                    {
                        End op = new End();
                        AddStmt(op);
                        AddLine();
                    }

                    Token tok = null;

                    try
                    {
                        tok = Tokens.Peek();
                    }
                    catch
                    {
                        break;
                    }

                    if (tok.TokenName.ToString() == "Colon")
                    {
                        Tokens.pos++;
                    }
                    else
                    {
                        AddLine();
                    }
                }
            }
        }

        static void ThrowError(string error)
        {
            Console.WriteLine("Parsing Error: " + error);
            while (true) { }
        }

        static void AddStmt(Stmt stmt)
        {
            if (current_line == null)
            {
                ThrowError("Can't add statement outside line");
            }
            else
            {
                current_line.Statements.Add(stmt);
            }
        }

        static void AddLine()
        {
            if (current_line == null)
            {
                ThrowError("Can't add null line");
            }
            else
            {
                Lines.Add(current_line);
                current_line = null;
            }
        }

        public List<Line> GetLines()
        {
            return Lines;
        }

        static Stmt ParseLet()
        {
            Expr expr1 = ParseExpr();

            if (Tokens.Peek().TokenName.ToString() == "Equal")
            {
                Tokens.pos++;
            }
            else
            {
                ThrowError("(ParseLet) Expected '=' on line " + current_line.Number);
            }

            Expr expr2 = ParseExpr();

            return new Let(expr1, expr2);
        }

        static Stmt ParsePrint()
        {
            if (Tokens.Peek().TokenName.ToString() == "IntLiteral" || Tokens.Peek().TokenName.ToString() == "LeftParan")
            {
                Expr expr = ParseExpr();

                if (Tokens.Peek().TokenName.ToString() == "SemiColon")
                {
                    Tokens.pos++;

                    return new Print(expr, true);
                }
                else
                {
                    return new Print(expr, false);
                }
            }
            else if (Tokens.Peek().TokenName.ToString() == "StringLiteral")
            {
                Token t = Tokens.GetToken();
                string s = t.TokenValue;

                if (Tokens.Peek().TokenName.ToString() == "SemiColon")
                {
                    return new PrintString(s, true);
                }
                else
                {
                    return new PrintString(s, false);
                }
            }
            else
            {
                ThrowError("(ParsePrint) Expression not in expected format on line " + current_line.Number);
            }

            return null;
        }

        static Stmt ParseInput()
        {
            Expr expr = ParseExpr();
            return new Input(expr);
        }

        static Stmt ParseGet()
        {
            Expr expr = ParseExpr();
            return new Get(expr);
        }

        static Stmt ParsePut()
        {
            Expr expr = ParseExpr();
            return new Put(expr);
        }

        static Expr ParseExpr()
        {
            Token t = Tokens.GetToken();
            Expr expression = null;

            if (t.TokenName.ToString() == "IntLiteral")
            {
                int i = Convert.ToInt32(t.TokenValue.ToString());
                Constant c = new Constant(i);

                if (Tokens.Peek().TokenName.ToString() == "Add")
                {
                    Tokens.pos++;
                    Expr expr = ParseExpr();
                    expression = new MathExpr(c, Symbol.add, expr);
                }
                else if (Tokens.Peek().TokenName.ToString() == "Sub")
                {
                    Tokens.pos++;
                    Expr expr = ParseExpr();
                    expression = new MathExpr(c, Symbol.sub, expr);
                }
                else if (Tokens.Peek().TokenName.ToString() == "Mul")
                {
                    Tokens.pos++;
                    Expr expr = ParseExpr();
                    expression = new MathExpr(c, Symbol.mul, expr);
                }
                else if (Tokens.Peek().TokenName.ToString() == "Div")
                {
                    Tokens.pos++;
                    Expr expr = ParseExpr();
                    expression = new MathExpr(c, Symbol.div, expr);
                }
                else
                {
                    expression = c;
                }
            }
            else if (t.TokenName.ToString() == "LeftParan")
            {
                Expr e = ParseExpr();

                if (Tokens.Peek().TokenName.ToString() == "RightParan")
                {
                    Tokens.pos++;
                }
                else
                {
                    ThrowError("(ParseExpr) Expected ')' on line " + current_line.Number);
                }

                ParanExpr p = new ParanExpr(e);

                if (Tokens.Peek().TokenName.ToString() == "Add")
                {
                    Tokens.pos++;
                    Expr expr = ParseExpr();
                    expression = new MathExpr(p, Symbol.add, expr);
                }
                else if (Tokens.Peek().TokenName.ToString() == "Sub")
                {
                    Tokens.pos++;
                    Expr expr = ParseExpr();
                    expression = new MathExpr(p, Symbol.sub, expr);
                }
                else if (Tokens.Peek().TokenName.ToString() == "Mul")
                {
                    Tokens.pos++;
                    Expr expr = ParseExpr();
                    expression = new MathExpr(p, Symbol.mul, expr);
                }
                else if (Tokens.Peek().TokenName.ToString() == "Div")
                {
                    Tokens.pos++;
                    Expr expr = ParseExpr();
                    expression = new MathExpr(p, Symbol.div, expr);
                }
                else
                {
                    expression = p;
                }
            }
            else
            {
                ThrowError("(ParseExpr) Expected expression on line " + current_line.Number);
            }

            return expression;
        }
    }
}
