using System;
using System.Collections.Generic;
using SchoolScript.Tokens;

namespace SchoolScript
{
    class Run
    {
        static void Main(string[] args)
        {
            string code = "var a = 1 + 1; \nprint(a,\"I'm script\");";
            Lexer lexer = new Lexer(code);
            foreach (IToken token in lexer.GetContent())
            {
                System.Console.WriteLine($"Token (Type: {token.Type}; Value: \"{token.Value}\")");
            }
        }           
    }
}
