using System;
using SchoolScript.AST;
using SchoolScript.Tokens;
using System.Collections.Generic;


namespace SchoolScript.ParserClasses
{
    public class EquationParser : Parser
    {

        public EquationParser(TokenControl tokens) : base (tokens)
        {
            _result = Parse();
        }

        private ICompound Parse()
        {
            List<ICompound> operands = new List<ICompound>();
            List<IToken> tokenOperands = new List<IToken>();
            EquationSign sign = EquationSign.NONE;

            tokenOperands.Add(_tokens.GetCurrent());
            _tokens.NextToken();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.EQUATION_SIGN);
            sign = DetermineSign(_tokens.GetCurrent().Value);
            _tokens.NextToken();

            tokenOperands.Add(_tokens.GetCurrent());
            
            foreach (IToken operand in tokenOperands)
            {
                if (operand.Type == TokenType.IDENTIFIER)
                {
                    var variableCall = new VariableCall(operand.Value);
                    operands.Add(variableCall);
                }
                else if (operand.Type == TokenType.BOOLEAN)
                {
                    bool value = bool.Parse(operand.Value);
                    operands.Add(new AST.Boolean(value));
                }
                else if (operand.Type == TokenType.NUMBER)
                {
                    int value = int.Parse(operand.Value);
                    operands.Add(new Integer(value));
                }
                else if (operand.Type == TokenType.STRING)
                {
                    operands.Add(new AST.String(operand.Value));
                } 
            }

            return new Equation(operands, sign);
        }

        private EquationSign DetermineSign(string sign)
        {
            if (sign == "<") return EquationSign.LESS;
            else if (sign == ">") return EquationSign.BIGGER;
            else if (sign == "==") return EquationSign.EQUAL;
            
            throw new NotImplementedException("error: cannot determine equation sign");
        }
    }
}