using System;
using SchoolScript.AST;
using SchoolScript.Tokens;


namespace SchoolScript.ParserClasses
{
    public class ValueParser : Parser
    {
        public ValueParser(TokenControl tokens) : base(tokens)
        {
            _result = Parse();
        }

        private ICompound Parse()
        {
            ICompound result;
            if (_tokens.GetCurrent().Type == TokenType.STRING)
            {
                result = new AST.String(_tokens.GetCurrent().Value);
                _tokens.NextToken();
            }
            else if (IsMathOperation())
            {
                var mathOperationParser = new MathOperationParser(_tokens);
                result = mathOperationParser.GetContent();
                _tokens.NextToken();
            }
            else if (_tokens.GetCurrent().Type == TokenType.NUMBER)
            {
                int value = int.Parse(_tokens.GetCurrent().Value);
                result = new AST.Integer(value);
                _tokens.NextToken();
            }
            else if (_tokens.GetCurrent().Type == TokenType.BOOLEAN)
            {
                bool value = bool.Parse(_tokens.GetCurrent().Value);
                result = new AST.Boolean(value);
                _tokens.NextToken();
            }
            else if (_tokens.GetCurrent().Type == TokenType.IDENTIFIER)
            {
                result = new VariableCall(_tokens.GetCurrent().Value);
                _tokens.NextToken();
            }
            else
            {
                throw new NotImplementedException("error: value is not recognized");
            }

            return result;
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