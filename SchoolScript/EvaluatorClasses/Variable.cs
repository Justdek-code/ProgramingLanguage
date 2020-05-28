using System;
using SchoolScript.AST;


namespace SchoolScript.EvaluatorClasses
{
    public enum VariableType
    {
        INTEGER,
        STRING,
        BOOLEAN,
        NULL
    }

    public class Variable
    {
        public VariableType Type;
        private AST.String _stringValue;
        private AST.Integer _intValue;
        private AST.Boolean _boolValue;


        public Variable(string value)
        {
            Type = VariableType.STRING;
            _stringValue = new AST.String(value);
        }

        public Variable(int value)
        {
            Type = VariableType.INTEGER;
            _intValue = new AST.Integer(value);
        }

        public Variable(bool value)
        {
            Type = VariableType.BOOLEAN;
            _boolValue = new AST.Boolean(value);
        }

        public Variable()
        {
            Type = VariableType.NULL;
        }

        public ICompound GetContent()
        {
            if (Type == VariableType.INTEGER)
            {
                return _intValue;
            }
            else if (Type == VariableType.STRING)
            {
                return _stringValue;
            }
            else if (Type == VariableType.BOOLEAN)
            {
                return _boolValue;
            }

            throw new NotImplementedException("error: variable is not initialized");
        }
    }
}