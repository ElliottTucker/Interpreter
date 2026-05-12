using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Interpreter
{
    public enum TokenType
    {
        //Values
        Number,
        String,
        Bool,
        Identifier,

        //Keys
        Let,
        If,
        Else,
        Print,
        While,
        True,
        False,

        //Arithmatic
        Plus,
        Minus,
        Star,
        Slash,

        //Symbols
        Assign, //=
        LeftBrace, RightBrace, //{ }
        LeftParen, RightParen, //( )

        //Comparison 
        Equals, //==
        NotEquals,
        Less,
        Greater,
        LessEq,
        GreaterEq,
            
        //End of file
        EOF 
    }

    public class Token
    {
        public TokenType TypeOfToken;
        public string TextInput;
        public Token(TokenType tokenType,string textInput)
        {
            TypeOfToken = tokenType;
            TextInput = textInput;
        }

        public override string ToString()
        {
            return ($"[{TypeOfToken} : {TextInput}]");
        }
    }
}
