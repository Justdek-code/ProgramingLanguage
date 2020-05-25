using System;
using System.Collections.Generic;
using SchoolScript.AST;

namespace SchoolScript.EvaluatorClasses
{
    public class Math
    {
        private int _result;


        public Math(ICompound expression)
        {
            _result = Calculate((IMathOperation) expression).IntegerValue;            
        }

        public int GetContent()
        {
            return _result;
        }

        private Integer Calculate(IMathOperation expression)
        {
            string operation = expression.Operation;
            Integer result = new Integer(0);
            List<Integer> solvedOperands = new List<Integer>();
            List<ICompound> operands = expression.Leaves;
            
            for (int i = 0; i < 2; i++)
            {
                if (operands[i].Type == ASTType.MATH_OPERATION)
                {
                    solvedOperands.Add(Calculate((IMathOperation) operands[i]));
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

        private Integer addition (Integer a, Integer b)
        {
            return new Integer(a.IntegerValue + b.IntegerValue);
        }

        private Integer subtraction(Integer a, Integer b)
        {
            return new Integer(a.IntegerValue - b.IntegerValue);
        }

        private Integer division(Integer a, Integer b)
        {
            return new Integer(a.IntegerValue / b.IntegerValue);
        }

        private Integer multiplication(Integer a, Integer b)
        {
            return new Integer(a.IntegerValue * b.IntegerValue);
        }
    }
}
