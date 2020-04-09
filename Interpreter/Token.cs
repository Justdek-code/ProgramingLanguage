namespace Interpreter
{
    public enum TokenType
    {
        ID,
        STRING,
        COMMA,
        ASSIGNMENT,
        SEMI,
        LPARENTHESIS,
        RPARENTHESIS,
    }

    public class Token
    {
        public TokenType Type { get; private set; }     
        public string Value { get; private set; }

        public Token (TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public Token (char symbol, string value)
        {
            Type = GetTokenType(symbol);
            Value = value;
        }

        private TokenType GetTokenType (char type)
        {
            if (type == '=') return TokenType.ASSIGNMENT;
            else if (type == ';') return TokenType.SEMI;
            else if (type == '(') return TokenType.LPARENTHESIS;
            else if (type == ')') return TokenType.RPARENTHESIS;
            else if (type == ',') return TokenType.COMMA;

            return TokenType.ID;
        }
    }
}