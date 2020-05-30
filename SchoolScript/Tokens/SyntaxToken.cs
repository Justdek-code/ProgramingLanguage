using System.Collections.Generic;
using System;

namespace SchoolScript.Tokens
{
    public class SyntaxToken : IToken
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }
        private List<string> _mathOperations;
        private List<string> _equation_signs;


        public SyntaxToken(string identifier)
        {
            _mathOperations = new List<string> { "+", "-", "/", "*"};
            _equation_signs = new List<string> { "==", "<", ">" };
            Type = TokenTypeOf(identifier);
            Value = identifier;
        }

        private TokenType TokenTypeOf(string identifier)
        {
            if (identifier == "=") return TokenType.ASSIGNMENT;
            else if (identifier == ";") return TokenType.SEMI;
            else if (identifier == "(") return TokenType.LPARENTHESIS;
            else if (identifier == ")") return TokenType.RPARENTHESIS;
            else if (identifier == ",") return TokenType.COMMA;
            else if (identifier == "{") return TokenType.LCURLY_BRACE;
            else if (identifier == "}") return TokenType.RCURLY_BRACE;
            else if (_equation_signs.Contains(identifier)) return TokenType.EQUATION_SIGN;
            else if (_mathOperations.Contains(identifier)) return TokenType.MATH_OPERATION;

            throw new NotImplementedException("Syntax token is not recognized");
        }
    }
}