using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    internal class Lexer
    {
        string InputCode;
        int Position;
        public Lexer(string input)
        {
            InputCode = input;
            Position = 0;
        }
        public List<Token> Tokenise()
        {
            List<Token> TokenList = new List<Token>();
            while(Position<InputCode.Length)
            {
                char current = InputCode[Position];
                //whiteSpace
                if(char.IsWhiteSpace(current))
                {
                    Position++;
                    continue;
                }
                //Comments
                if (current == '/' && Position + 1 < InputCode.Length && InputCode[Position + 1] == '/')
                {
                    while (Position < InputCode.Length && InputCode[Position] != '\n')
                    {
                        Position++;
                    }
                    continue;
                }
                //Single chars
                switch (current)
                {
                    case '+':
                        TokenList.Add(new Token(TokenType.Plus, "+"));
                        Position++;
                        break;
                    case '-':
                        TokenList.Add(new Token(TokenType.Minus, "-"));
                        Position++;
                        break;
                    case '*':
                        TokenList.Add(new Token(TokenType.Star, "*"));
                        Position++;
                        break;
                    case '/':
                        TokenList.Add(new Token(TokenType.Slash, "/"));
                        Position++;
                        break;
                    case '{':
                        TokenList.Add(new Token(TokenType.LeftBrace, "{"));
                        Position++;
                        break;
                    case '}':
                        TokenList.Add(new Token(TokenType.RightBrace, "}"));
                        Position++;
                        break;
                    case '(':
                        TokenList.Add(new Token(TokenType.LeftParen, "("));
                        Position++;
                        break;
                    case ')':
                        TokenList.Add(new Token(TokenType.RightParen, ")"));
                        Position++;
                        break;
                    case '=':
                        if(Position + 1 < InputCode.Length && InputCode[Position + 1] == '=')
                        {
                            TokenList.Add(new Token(TokenType.Equals, "=="));
                            Position+=2;
                        }
                        else
                        {
                            TokenList.Add(new Token(TokenType.Assign, "="));
                            Position++;
                        }
                        break;
                    case '>':
                        if(Position + 1 < InputCode.Length && InputCode[Position + 1] == '=')
                        {
                            TokenList.Add(new Token(TokenType.GreaterEq, ">="));
                            Position += 2;
                        }
                        else
                        {
                            TokenList.Add(new Token(TokenType.Greater, ">"));
                            Position ++;
                        }
                    break;
                    case '<':
                        if (Position + 1 < InputCode.Length && InputCode[Position + 1] == '=')
                        {
                            TokenList.Add(new Token(TokenType.LessEq, "<="));
                            Position += 2;
                        }
                        else
                        {
                            TokenList.Add(new Token(TokenType.Less, "<"));
                            Position++;
                        }
                        break;
                    case '!':
                        if (Position + 1 < InputCode.Length && InputCode[Position + 1] == '=')
                        {
                            TokenList.Add(new Token(TokenType.NotEquals, "!="));
                            Position += 2;
                        }
                        else
                        {
                            Position++;
                        }
                        break;
                    default:
                        if (!char.IsLetter(current) && !char.IsDigit(current) && current != '"')
                            Position++;
                        break;
                }
                //digits
                if(char.IsDigit(current))
                {
                    StringBuilder Number = new StringBuilder();
                    while (Position < InputCode.Length && char.IsDigit(InputCode[Position]))
                    {
                        Number.Append(InputCode[Position]);
                        Position++;
                    }
                    TokenList.Add(new Token(TokenType.Number, Number.ToString()));
                }
                //strings
                if(current == '"')
                {                             
                    Position++;
                    StringBuilder String = new StringBuilder();
                    while (Position < InputCode.Length && InputCode[Position]!='"')
                    {
                        String.Append(InputCode[Position]);
                        Position++;
                    }
                    TokenList.Add(new Token(TokenType.String, String.ToString()));
                    Position++;
                }
                //keys and identifiers
                if (char.IsLetter(current))
                {
                    StringBuilder WordBuilder = new StringBuilder();
                    while (Position < InputCode.Length && char.IsLetter(InputCode[Position]))
                    {
                        WordBuilder.Append(InputCode[Position]);
                        Position++;
                    }
                    string Word = WordBuilder.ToString();
                    switch (Word)
                    {
                        case "let":
                            TokenList.Add(new Token(TokenType.Let, Word));
                            break;
                        case "if":
                            TokenList.Add(new Token(TokenType.If, Word));
                            break;
                        case "else":
                            TokenList.Add(new Token(TokenType.Else, Word));
                            break;
                        case "print":
                            TokenList.Add(new Token(TokenType.Print, Word));
                            break;
                        case "while":
                            TokenList.Add(new Token(TokenType.While, Word));
                            break;
                        case "true":
                            TokenList.Add(new Token(TokenType.True, Word));
                            break;
                        case "false":
                            TokenList.Add(new Token(TokenType.False, Word));
                            break;
                        default:
                            TokenList.Add(new Token(TokenType.Identifier, Word));
                            break;
                    }
                }
            }
            TokenList.Add(new Token(TokenType.EOF, ""));
            return TokenList;
        }
    }
}
