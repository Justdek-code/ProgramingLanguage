using System;
using SchoolScript.AST;
using SchoolScript.Tokens;


namespace SchoolScript.ParserClasses
{
    public class ValueParser : Parser
    {
        public ValueParser(TokenControl tokens) : base(tokens)
        {
            Parse();
        }

        private void Parse()
        {
            if (_tokens.GetCurrent().Type == TokenType.STRING)
            {
                _result = new AST.String(_tokens.GetCurrent().Value);
                _tokens.NextToken();
            }
            else if (IsMathOperation())
            {
                var mathOperationParser = new MathOperationParser(_tokens);
                _result = mathOperationParser.GetContent();
                _tokens.NextToken();
            }
            else if (_tokens.GetCurrent().Type == TokenType.NUMBER)
            {
                int value = int.Parse(_tokens.GetCurrent().Value);
                _result = new AST.Integer(value);
                _tokens.NextToken();
            }
            else if (_tokens.GetCurrent().Type == TokenType.IDENTIFIER)
            {
                _result = new VariableCall(_tokens.GetCurrent().Value);
                _tokens.NextToken();
            }
        }

        private bool IsMathOperation()
        {
            if (_tokens.GetCurrent().Type == TokenType.NUMBER ||
                _tokens.GetCurrent().Type == TokenType.IDENTIFIER)
            {
                _tokens.NextToken();
                if (_tokens.GetCurrent().Type == TokenType.MATH_OPERATION)
                {
                    _tokens.PreviousToken();
                    return true;
                }
                _tokens.PreviousToken();
            }

            return false;
        }
    }
}