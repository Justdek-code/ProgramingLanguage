using System;
using System.Collections.Generic;
using SchoolScript.AST;

namespace SchoolScript.EvaluatorClasses
{
    public class Math
    {
        private IInteger _result;
        private VariablesHeap _variables;


        public Math(ICompound expression, VariablesHeap variables)
        {
            _variables = variables;
            _result = Calculate((IMathOperation) expression);            
        }

        public IInteger GetContent()
        {
            return _result;
        }

        private IInteger Calculate(IMathOperation expression)
        {
            string operation = expression.Operation;
            IInteger result = new Integer(0);
            List<IInteger> solvedOperands = new List<IInteger>();
            List<ICompound> operands = expression.Leaves;
            
            for (int i = 0; i < 2; i++)
            {
                if (operands[i].Type == ASTType.MATH_OPERATION)
                {
                    solvedOperands.Add(Calculate((IMathOperation) operands[i]));
                }
                else if (operands[i].Type == ASTType.VARIABLE_CALL)
                {
                    IVariableCall variableCall = (IVariableCall) operands[i];
                    Variable variable = _variables.GetVariable(variableCall.VariableName);
                    solvedOperands.Add((IInteger) variable.GetContent());
                }
                else
                {
                    solvedOperands.Add((Integer) operands[i]);
                }
            }
            
            if (operation == "+") result = addition(solvedOperands[0], solvedOperands[1]);
            else if (operation == "-") result = subtraction(solvedOperands[0], solvedOperands[1]);
            else if (operation == "/") result = division(solvedOperands[0], solvedOperands[1]);
            else if (operation == "*") result = multiplication(solvedOperands[0], solvedOperands[1]);

            return result;
        }

        private IInteger addition (IInteger a, IInteger b)
        {
            return new Integer(a.IntegerValue + b.IntegerValue);
        }

        private IInteger subtraction(IInteger a, IInteger b)
        {
            return new Integer(a.IntegerValue - b.IntegerValue);
        }

        private IInteger division(IInteger a, IInteger b)
        {
            return new Integer(a.IntegerValue / b.IntegerValue);
        }

        private IInteger multiplication(IInteger a, IInteger b)
        {
            return new Integer(a.IntegerValue * b.IntegerValue);
        }
    }
}
