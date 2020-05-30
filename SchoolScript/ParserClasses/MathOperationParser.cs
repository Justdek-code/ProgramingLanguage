using System;
using System.Collections.Generic;
using SchoolScript.AST;
using SchoolScript.Tokens;


namespace SchoolScript.ParserClasses
{
    public class MathOperationParser : Parser
    {
        public MathOperationParser(TokenControl tokens) : base(tokens)
        {
            _result = Parse();
        }

        private ICompound Parse()
        {
            List<ICompound> operands = new List<ICompound>();
            string operation = string.Empty;
            List<IToken> tokenOperands = new List<IToken>();

            tokenOperands.Add(_tokens.GetCurrent());
            _tokens.NextToken();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.MATH_OPERATION);
            operation = _tokens.GetCurrent().Value;
            _tokens.NextToken();

            tokenOperands.Add(_tokens.GetCurrent());

            foreach (IToken operand in tokenOperands)
            {
                if (operand.Type == TokenType.IDENTIFIER)
                {
                    var variableCall = new VariableCall(operand.Value);
                    operands.Add(variableCall);
                }
                else if (operand.Type == TokenType.NUMBER)
                {
                    int value = int.Parse(operand.Value);
                    operands.Add(new Integer(value));
                }
            }

            var mathOperation = new MathOperation(operands, operation);
            return mathOperation;
        }
    }
}