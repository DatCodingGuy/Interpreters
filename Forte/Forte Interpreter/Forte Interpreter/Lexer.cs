using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Forte_Interpreter
{
    public class Lexer
    {
        private readonly Dictionary<Tokens, string> _tokens;
        private readonly Dictionary<Tokens, MatchCollection> _regExMatchCollection;
        private string _inputString;
        private int _index;

        public enum Tokens
        {
            Undefined = 0,
            Let = 1,
            Print = 2,
            Input = 3,
            Get = 4,
            Put = 5,
            StringLiteral = 6,
            IntLiteral = 7,
            Ident = 8,
            Whitespace = 9,
            NewLine = 10,
            Add = 11,
            Sub = 12,
            Mul = 13,
            Div = 14,
            Equal = 15,
            LeftParan = 16,
            RightParan = 17,
            Colon = 18,
            SemiColon = 19,
            End = 20
        }

        public string InputString
        {
            set
            {
                _inputString = value;
                PrepareRegex();
            }
        }

        public Lexer()
        {
            _tokens = new Dictionary<Tokens, string>();
            _regExMatchCollection = new Dictionary<Tokens, MatchCollection>();
            _index = 0;
            _inputString = string.Empty;

            _tokens.Add(Tokens.Let, "LET");
            _tokens.Add(Tokens.Print, "PRINT");
            _tokens.Add(Tokens.Input, "INPUT");
            _tokens.Add(Tokens.Get, "GET");
            _tokens.Add(Tokens.Put, "PUT");
            _tokens.Add(Tokens.End, "END");
            _tokens.Add(Tokens.StringLiteral, "\".*?\"");
            _tokens.Add(Tokens.IntLiteral, "[0-9]+");
            _tokens.Add(Tokens.Whitespace, "[ \\t]+");
            _tokens.Add(Tokens.NewLine, "\\n");
            _tokens.Add(Tokens.Add, "\\+");
            _tokens.Add(Tokens.Sub, "\\-");
            _tokens.Add(Tokens.Mul, "\\*");
            _tokens.Add(Tokens.Div, "\\/");
            _tokens.Add(Tokens.Equal, "\\=");
            _tokens.Add(Tokens.LeftParan, "\\(");
            _tokens.Add(Tokens.RightParan, "\\)");
            _tokens.Add(Tokens.Colon, "\\:");
            _tokens.Add(Tokens.SemiColon, "\\;");
        }

        private void PrepareRegex()
        {
            _regExMatchCollection.Clear();
            foreach (KeyValuePair<Tokens, string> pair in _tokens)
            {
                _regExMatchCollection.Add(pair.Key, Regex.Matches(_inputString, pair.Value));
            }
        }

        public void ResetParser()
        {
            _index = 0;
            _inputString = string.Empty;
            _regExMatchCollection.Clear();
        }

        public Token GetToken()
        {
            if (_index >= _inputString.Length)
                return null;

            foreach (KeyValuePair<Tokens, MatchCollection> pair in _regExMatchCollection)
            {
                foreach (Match match in pair.Value)
                {
                    if (match.Index == _index)
                    {
                        _index += match.Length;
                        return new Token(pair.Key, match.Value);
                    }

                    if (match.Index > _index)
                    {
                        break;
                    }
                }
            }
            _index++;
            return new Token(Tokens.Undefined, string.Empty);
        }

        public PeekToken Peek()
        {
            return Peek(new PeekToken(_index, new Token(Tokens.Undefined, string.Empty)));
        }

        public PeekToken Peek(PeekToken peekToken)
        {
            int oldIndex = _index;

            _index = peekToken.TokenIndex;

            if (_index >= _inputString.Length)
            {
                _index = oldIndex;
                return null;
            }

            foreach (KeyValuePair<Tokens, string> pair in _tokens)
            {
                Regex r = new Regex(pair.Value);
                Match m = r.Match(_inputString, _index);

                if (m.Success && m.Index == _index)
                {
                    _index += m.Length;
                    PeekToken pt = new PeekToken(_index, new Token(pair.Key, m.Value));
                    _index = oldIndex;
                    return pt;
                }
            }
            PeekToken pt2 = new PeekToken(_index + 1, new Token(Tokens.Undefined, string.Empty));
            _index = oldIndex;
            return pt2;
        }
    }

    public class PeekToken
    {
        public int TokenIndex { get; set; }

        public Token TokenPeek { get; set; }

        public PeekToken(int index, Token value)
        {
            TokenIndex = index;
            TokenPeek = value;
        }
    }

    public class Token
    {
        public Lexer.Tokens TokenName { get; set; }

        public string TokenValue { get; set; }

        public Token(Lexer.Tokens name, string value)
        {
            TokenName = name;
            TokenValue = value;
        }
    }

    public class TokenList
    {
        public List<Token> Tokens;
        public int pos = 0;

        public TokenList(Lexer lexer)
        {
            Tokens = new List<Token>();

            while (true)
            {
                try
                {
                    Token t = lexer.GetToken();

                    if (t.TokenName.ToString() != "Whitespace" && t.TokenName.ToString() != "NewLine" && t.TokenName.ToString() != "Undefined")
                    {
                        Tokens.Add(t);
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        public Token GetToken()
        {
            Token ret = Tokens[pos];
            pos++;
            return ret;
        }

        public Token Peek()
        {
            return Tokens[pos];
        }
    }
}
