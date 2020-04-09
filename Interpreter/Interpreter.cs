using System;

namespace Interpreter
{
    class Interpreter
    {
        static void Main(string[] args)
        {
            Lexer lexer = new Lexer("var a = \"Hello Wordl!\"");
            Token token = lexer.GetToken();

            while (token != null) 
            {
                Console.WriteLine($"TOKEN ( TYPE: {token.Type}; VALUE: {token.Value} )");

                lexer.NextToken();
                token = lexer.GetToken();
            }
            
            // TOKEN ( TYPE: ID; VALUE: var )
            // TOKEN ( TYPE: ID; VALUE: a )
            // TOKEN ( TYPE: ASSIGNMENT; VALUE: = )
            // TOKEN ( TYPE: STRING; VALUE: Hello Wordl! )

        }           
    }
}
