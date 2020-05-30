using System;
using SchoolScript.AST;
using SchoolScript.Tokens;
using System.Collections.Generic;


namespace SchoolScript.ParserClasses
{
    public class FunctionCallParser : Parser
    {

        public FunctionCallParser(TokenControl tokens) : base (tokens)
        {
            _result = Parse();
        }

        private ICompound Parse()
        {
            List<ICompound> arguments = new List<ICompound>();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.IDENTIFIER);
            string functionName = _tokens.GetCurrent().Value;
            _tokens.NextToken();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.LPARENTHESIS);
            _tokens.NextToken();

            while (true)
            {
                if (_tokens.GetCurrent().Type == TokenType.RPARENTHESIS)
                {
                    break;
                }

                ValueParser valueParser = new ValueParser(_tokens);
                arguments.Add(valueParser.GetContent());

                if (_tokens.GetCurrent().Type == TokenType.COMMA)
                {
                    _tokens.NextToken();
                }
            }
            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.RPARENTHESIS);
            _tokens.NextToken();

            return new FunctionCall(arguments, functionName);
        }
    }
}