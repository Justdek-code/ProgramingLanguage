using System;


namespace SchoolScript.EvaluatorClasses
{
    public enum VariableType
    {
        INTEGER,
        STRING,
        NULL
    }

    public class Variable
    {
        public VariableType Type;
        private string stringValue;
        private int intValue;


        public Variable(string value)
        {
            Type = VariableType.STRING;
            stringValue = value;
        }

        public Variable(int value)
        {
            Type = VariableType.INTEGER;
            intValue = value;
        }

        public Variable()
        {
            Type = VariableType.NULL;
        }

        public Variable Reassignment(string newValue)
        {
            return new Variable(newValue);
        }

        public Variable Reassignment(int newValue)
        {
            return new Variable(newValue);
        }

        public int GetIntValue()
        {
            if (Type == VariableType.STRING || Type == VariableType.NULL) 
            {
                throw new NotImplementedException("error: 'string' type variable cannot return 'int' or it is NULL");
            }

            return intValue;
        }

        public string GetStringValue()
        {
            if (Type == VariableType.INTEGER || Type == VariableType.NULL)
            {
                throw new NotImplementedException("error: 'int' type variable cannot return 'string' or it is NULL");
            }

            return stringValue;
        }
    }

}