using System;
using System.Collections.Generic;
using SchoolScript.AST;


namespace SchoolScript.EvaluatorClasses
{
    public class Compare 
    {
        private bool _result;
        private VariablesHeap _variables;
        private List<ICompound> _operands;
        private EquationSign _sign;


        public Compare(List<ICompound> operands, EquationSign sign, VariablesHeap variables)
        {
            _variables = variables;
            _operands = operands;
            _sign = sign;

            CompareOperands(operands, sign);
        }

        public bool GetContent()
        {
            return _result;
        }

        public void Update()
        {
            CompareOperands(_operands, _sign);
        }

        private void CompareOperands(List<ICompound> operands, EquationSign sign)
        {
            List<ICompound> values = new List<ICompound>();

            for (int i = 0; i < 2; i++)
            {
                if (operands[i].Type == ASTType.VARIABLE_CALL)
                {
                    IVariableCall variableCall = (IVariableCall) operands[i];
                    Variable variable = _variables.GetVariable(variableCall.VariableName);
                    values.Add(variable.GetContent());
                }
                else if (operands[i].Type == ASTType.MATH_OPERATION)
                {
                    Math math = new Math(operands[i], _variables);
                    values.Add(math.GetContent());
                }
                else 
                {
                    values.Add(operands[i]);
                }
            }

            if (CompareValues(values) == sign)
            {
                _result = true;
            }
            else
            {
                _result = false;
            } 
        }

        private EquationSign CompareValues(List<ICompound> operands)
        {
            if (IsInteger(operands[0]) && IsInteger(operands[1]))
            {
                return CompareIntegers(operands);
            }
            else if (IsString(operands[0]) && IsString(operands[1]))
            {
                return CompareStrings(operands);
            }
            else if (IsBoolean(operands[0]) && IsBoolean(operands[1]))
            {
                return CompareBooleans(operands);
            }

            throw new NotImplementedException("error: this variable type can't be compared");
        }   

        private bool IsBoolean(ICompound operand)
        {
            if (operand.Type == ASTType.BOOLEAN)
            {
                return true;
            }

            return false;
        }

        private bool IsInteger(ICompound operand)
        {
            if (operand.Type == ASTType.INTEGER)
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
            int firstValue = ((IInteger)(operands[0])).IntegerValue;
            int secondValue = ((IInteger)(operands[1])).IntegerValue;

            if (firstValue < secondValue) return EquationSign.LESS;
            else if (firstValue > secondValue) return EquationSign.BIGGER;
            else return EquationSign.EQUAL; 
        }

        private EquationSign CompareStrings(List<ICompound> operands)
        {
            IString str1 = (IString) operands[0];
            IString str2 = (IString) operands[1];
            if (str1.StringValue.Equals(str2.StringValue)) return EquationSign.EQUAL;

            return EquationSign.NONE;
        }

        private EquationSign CompareBooleans(List<ICompound> operands)
        {
            IBoolean firstValue = (IBoolean) operands[0];
            IBoolean secondValue = (IBoolean) operands[1];

            if (firstValue.BooleanValue == secondValue.BooleanValue) return EquationSign.EQUAL;

            return EquationSign.NONE;
        }
    }
}