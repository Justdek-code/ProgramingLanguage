using System;
using System.Collections.Generic;
using SchoolScript.AST;
using SchoolScript.Tokens;
using SchoolScript.InlineFunctions;


namespace SchoolScript.EvaluatorClasses
{

    public class Evaluator
    {
        private ICompound _compound;
        private VariablesHeap _variables;
        private FunctionsHeap _functions;


        public Evaluator(ICompound compound) // it future it will takes parser object 
        {
            _compound = compound;
            _variables = new VariablesHeap();
            _functions = new FunctionsHeap(_variables);
        }

        public void Run()
        {
            Execute(_compound.Leaves);
        }

        private void Execute(List<ICompound> statements)
        {
            foreach (ICompound statement in statements)
            {
                if (statement.Type == ASTType.VAR_DEFINITION)
                {
                    DefineVariable((IVariableDefinition) statement);
                }
                else if (statement.Type == ASTType.ASSIGNMENT)
                {
                    AssignVariableValue((IAssignment) statement);
                }
                else if (statement.Type == ASTType.FUNCTION_CALL)
                {
                    CallFunction((IFunctionCall) statement);
                }
                else if (statement.Type == ASTType.IF_STATEMENT)
                {
                    ProcessIfStatement((IStatementIf) statement);
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

        private void DefineVariable(IVariableDefinition definition)
        {
            Variable newVar = new Variable();
            _variables.AddVariable(definition.VariableDefinitionName, newVar);

            if (definition.Leaves[0].Type == ASTType.ASSIGNMENT)
            {
                IAssignment varInitialization = (IAssignment) definition.Leaves[0];
                AssignVariableValue(varInitialization);
            }
        }

        private void AssignVariableValue(IAssignment assignment)
        {
            string variableName = assignment.VariableName;
            ICompound value = assignment.Leaves[0];

            if (value.Type == ASTType.STRING)
            {
                IString variable = (IString) value;
                _variables.AddVariable(variableName, new Variable(variable.StringValue));
            }
            else if (value.Type == ASTType.INTEGER)
            {
                IInteger variable = (IInteger) value;
                _variables.AddVariable(variableName, new Variable(variable.IntegerValue));
            }
            else if (value.Type == ASTType.BOOLEAN)
            {
                IBoolean variable = (IBoolean) value;
                _variables.AddVariable(variableName, new Variable(variable.BooleanValue));
            }
            else if (value.Type == ASTType.MATH_OPERATION)
            {
                Math math = new Math(value);
                Integer result = math.GetContent();
                _variables.AddVariable(variableName, new Variable(result.IntegerValue));
            }
        }

        private void CallFunction(IFunctionCall callFunction)
        {
            IFunction function = _functions.GetFunction(callFunction.FunctionName);
            function.Invoke(callFunction.Leaves);
        }

        private void ProcessIfStatement(IStatementIf ifStatment)
        {
            IEquation equation = (IEquation) ifStatment.Equation;
            Compare compare = new Compare(equation.Leaves, equation.Sign);
           
            if (compare.GetContent() == true)
            {
                Execute(ifStatment.Leaves);
            }
        }
    }
}