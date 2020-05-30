using System;
using SchoolScript.AST;
using SchoolScript.Tokens;
using System.Collections.Generic;


namespace SchoolScript.ParserClasses
{
    public class WhileLoopParser : Parser
    {
        public delegate List<ICompound> Parsing();


        public WhileLoopParser(TokenControl tokens, Parsing parseStatments) : base (tokens)
        {
            _result = Parse(parseStatments);
        }

        private ICompound Parse(Parsing blockParsing)
        {
            CheckSyntaxCorrectness(_tokens.GetCurrent(), "while");
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

            List<ICompound> loopBlock = blockParsing();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.RCURLY_BRACE);     

            return new WhileLoop(equation, loopBlock);   
        }
    }
}