using System;
using SchoolScript.AST;
using SchoolScript.Tokens;


namespace SchoolScript.ParserClasses
{
    public class VariableDefinitionParser : Parser
    {
        public VariableDefinitionParser(TokenControl tokens) : base(tokens)
        {
            Parse();
        }

        private void Parse()
        {
            CheckSyntaxCorrectness(_tokens.GetCurrent(), "var");
            _tokens.NextToken();

            var assignmentParser = new AssignmentParser(_tokens);
            IAssignment assignment = (IAssignment) assignmentParser.GetContent();

            var variableDefiniton = new VariableDefinition(assignment.VariableName, assignment);
            _result = variableDefiniton;
        }
    }
}