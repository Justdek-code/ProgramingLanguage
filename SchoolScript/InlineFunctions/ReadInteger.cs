using System;
using SchoolScript.AST;
using System.Collections.Generic;
using SchoolScript.EvaluatorClasses;


namespace SchoolScript.InlineFunctions
{
    public class ReadInteger : Function
    {

        public ReadInteger(VariablesHeap variables) : base(variables)
        {
        }

        public override void Invoke(List<ICompound> arguments)
        {
            foreach (ICompound argument in arguments)
            {
                ReadInt((IVariableCall) argument);
            }
        }

        private void ReadInt(IVariableCall variable)
        {
            string value = Console.ReadLine();
            int number = int.Parse(value);
            _variables.AssignVariable(variable.VariableName, new Variable(number));
        }
    }
}