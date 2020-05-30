using System;
using SchoolScript.AST;
using SchoolScript.Tokens;


namespace SchoolScript.ParserClasses
{
    public class VariableDefinitionParser : Parser
    {
        public VariableDefinitionParser(TokenControl tokens) : base(tokens)
        {
            _result = Parse();
        }

        private ICompound Parse()
        {
            CheckSyntaxCorrectness(_tokens.GetCurrent(), "var");
            _tokens.NextToken();

            var assignmentParser = new AssignmentParser(_tokens);
            IAssignment assignment = (IAssignment) assignmentParser.GetContent();

            var variableDefiniton = new VariableDefinition(assignment.VariableName, assignment);
            return variableDefiniton;
        }
    }
}