using System;
using SchoolScript.AST;
using System.Collections.Generic;
using SchoolScript.EvaluatorClasses;


namespace SchoolScript.Functions
{
    public abstract class Function
    {
        protected VariablesHeap _variables;


        public Function(VariablesHeap variables)
        {
            _variables = variables;
        }

        public abstract void Invoke(List<ICompound> arguments);
    }
}