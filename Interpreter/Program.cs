using System;
using System.Collections.Generic;
using System.IO;

namespace Interpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string source = File.ReadAllText("InputFile.tauri");
            Lexer lexer = new Lexer(source);
            List<Token> tokens = lexer.Tokenise();
            foreach (Token t in tokens)
            {
                Console.WriteLine(t);
            }
        }
    }
}