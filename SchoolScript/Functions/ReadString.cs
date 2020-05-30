using System;
using SchoolScript.AST;
using System.Collections.Generic;
using SchoolScript.EvaluatorClasses;


namespace SchoolScript.Functions
{
    public class ReadString : Function
    {

        public ReadString(VariablesHeap variables) : base(variables)
        {
        }

        public override void Invoke(List<ICompound> arguments)
        {
            foreach (ICompound argument in arguments)
            {
                ReadStr((IVariableCall) argument);
            }
        }

        private void ReadStr(IVariableCall variable)
        {
            string value = Console.ReadLine();
            _variables.AssignVariable(variable.VariableName, new Variable(value));
        }
    }
}