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
            VariableDefinition definition = (VariableDefinition) statement;
            _variableHeap.Add(definition.VariableDefinitionName, newVar);
        }
    }
}