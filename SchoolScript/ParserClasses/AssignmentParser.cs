using System;
using SchoolScript.AST;
using SchoolScript.Tokens;


namespace SchoolScript.ParserClasses
{
    public class AssignmentParser : Parser
    {
        public AssignmentParser(TokenControl tokens) : base(tokens)
        {
            _result = Parse();
        }

        private ICompound Parse()
        {
            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.IDENTIFIER);
            string variableName = _tokens.GetCurrent().Value;
            _tokens.NextToken();

            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.ASSIGNMENT);
            _tokens.NextToken();

            var valueParser = new ValueParser(_tokens);
            
            IAssignment assignment = new Assignment(variableName, valueParser.GetContent());
            
            CheckSyntaxCorrectness(_tokens.GetCurrent(), TokenType.SEMI);
            return assignment;
        }
    }
}