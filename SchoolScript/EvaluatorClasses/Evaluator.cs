using System;
using System.Collections.Generic;
using SchoolScript.AST;
using SchoolScript.Tokens;

namespace SchoolScript.EvaluatorClasses
{

    public class Evaluator
    {
        private ICompound _compound;
        private Dictionary<string, Variable> _variableHeap;


        public Evaluator(ICompound compound) // it future it will takes parser object 
        {
            _compound = compound;
            _variableHeap = new Dictionary<string, Variable>();
        }

        public void Execute()
        {
            foreach (ICompound statement in _compound.Leaves)
            {
                if (statement.Type == ASTType.VAR_DEFINITION)
                {
                    DefineVariable(statement);
                }
                else if (statement.Type == ASTType.ASSIGNMENT)
                {
                    AssignVariableValue(statement);
                }
                else if (statement.Type == ASTType.FUNCTION_CALL)
                {

                }
                else if (statement.Type == ASTType.IF_STATEMENT)
                {

                }
                else if (statement.Type == ASTType.FOR_LOOP)
                {

                }
                else 
                {
                    throw new NotImplementedException("error: statement is not recognized");
                }

            }
        }

        private void DefineVariable(ICompound statement)
        {
            Variable newVar = new Variable();
            IVariableDefinition definition = (IVariableDefinition) statement;
            _variableHeap.Add(definition.VariableDefinitionName, newVar);

            AssignVariableValue( definition.Leaves[0]);
        }

        private void AssignVariableValue(ICompound assignment)
        {
            IAssignment varAssignment = (IAssignment) assignment;
            string variableName = varAssignment.VariableName;
            ICompound value = varAssignment.Leaves[0];

            if (!_variableHeap.ContainsKey(variableName))
            {
                throw new NotImplementedException($"error: variable '{variableName}' is not defined");
            }

            if (value.Type == ASTType.STRING)
            {
                IString str = (IString) value;
                _variableHeap[variableName] = new Variable(str.StringValue);
            }
            else if (value.Type == ASTType.INTEGER)
            {
                IInteger number = (IInteger) value;
                _variableHeap[variableName] = new Variable(number.IntegerValue);
            }
            else if (value.Type == ASTType.MATH_OPERATION)
            {
                Math math = new Math(value);
                _variableHeap[variableName] = new Variable(math.GetContent());
            }
        }
    }
}