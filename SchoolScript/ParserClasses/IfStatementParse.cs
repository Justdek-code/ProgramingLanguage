using System;
using SchoolScript.AST;
using SchoolScript.Tokens;
using System.Collections.Generic;


namespace SchoolScript.ParserClasses
{
    public class IfStatementParser : Parser
    {
        public delegate List<ICompound> Parsing();


        public IfStatementParser(TokenControl tokens, Parsing parseStatments) : base (tokens)
        {
            _result = Parse(parseStatments);
        }

        private ICompound Parse(Parsing blockParsing)
        {
            CheckSyntaxCorrectness(_tokens.GetCurrent(), "if");
            _tokens.NextToken();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.LPARENTHESIS);
            _tokens.NextToken();

            EquationParser equationParser = new EquationParser(_tokens);
            ICompound equation = equationParser.GetContent();
            _tokens.NextToken();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.RPARENTHESIS);
            _tokens.NextToken();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.LCURLY_BRACE);
            _tokens.NextToken();

            List<ICompound> block = blockParsing();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.RCURLY_BRACE);     

            return new If(equation, block);   
        }
    }
}