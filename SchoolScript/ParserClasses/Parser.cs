using System;
using SchoolScript.AST;
using SchoolScript.Tokens;


namespace SchoolScript.ParserClasses
{  
    public abstract class Parser
    {
        protected TokenControl _tokens;
        protected ICompound _result;


        public Parser(TokenControl tokens)
        {
            _tokens = tokens;
        }

        public ICompound GetContent()
        {
            return _result;
        }

        protected void CheckSyntaxCorrectness(IToken token, string desireValue)
        {
            if (token.Value != desireValue)
            {
                throw new NotImplementedException("error: syntax error;");
            }
        }

        protected void CheckSyntaxCorrectness(IToken token, TokenType desireType)
        {
            if (token.Type != desireType)
            {
                throw new NotImplementedException("error: syntax error;");
            }
        }
    }
}