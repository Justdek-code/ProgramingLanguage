namespace SchoolScript.Tokens
{
    public interface IToken
    {
        TokenType Type { get; set; }
        string Value { get; set; }
    }
}