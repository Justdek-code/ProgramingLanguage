namespace SchoolScript.Tokens
{
    public class Token : IToken
    {
        public TokenType Type { get; set; }     
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}