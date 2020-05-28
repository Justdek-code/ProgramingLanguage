using System;
using System.Collections.Generic;
using SchoolScript.AST;


namespace SchoolScript.EvaluatorClasses
{
    public class Compare
    {
        private bool _result;


        public Compare(List<ICompound> operands, EquationSign sign)
        {
            if (sign == CompareOperands(operands))
            {
                _result = true;
            }
            else 
            {
                _result = false;
            }
        }

        public bool GetContent()
        {
            return _result;
        }

        private EquationSign CompareOperands(List<ICompound> operands)
        {

            if (IsInteger(operands[0]) && IsInteger(operands[1]))
            {
                return CompareIntegers(operands);
            }
            else if (IsString(operands[0]) && IsString(operands[1]))
            {
                return CompareStrings(operands);
            }
            

            throw new NotImplementedException("error: this variable type can't be compared");
        }   

        private bool IsInteger(ICompound operand)
        {
            if (operand.Type == ASTType.INTEGER || operand.Type == ASTType.MATH_OPERATION)
            {
                return true;
            }
            
            return false;
        }   

        private bool IsString(ICompound operand)
        {
            if (operand.Type == ASTType.STRING)
            {
                return true;
            }

            return false;
        }  

        private EquationSign CompareIntegers(List<ICompound> operands)
        {
            List<int> solvedOperands = new List<int>();

            foreach (ICompound operand in operands)
            {
                if (operand.Type == ASTType.MATH_OPERATION)
                {
                    Math math = new Math(operand);
                    solvedOperands.Add(math.GetContent().IntegerValue);
                }
                else
                {
                    Integer value = (Integer) operand;
                    solvedOperands.Add(value.IntegerValue);
                }
            }

            if (solvedOperands[0] < solvedOperands[1]) return EquationSign.LESS;
            else if (solvedOperands[0] > solvedOperands[1]) return EquationSign.BIGGER;
            else return EquationSign.EQUAL; 
        }

        private EquationSign CompareStrings(List<ICompound> operands)
        {
            IString str1 = (IString) operands[0];
            IString str2 = (IString) operands[1];
            if (str1.StringValue.Equals(str2.StringValue)) return EquationSign.EQUAL;

            return EquationSign.NONE;
        }
    }
}