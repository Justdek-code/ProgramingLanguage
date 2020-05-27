using System.Collections.Generic;
using SchoolScript.InlineFunctions;


namespace SchoolScript.EvaluatorClasses
{
    public class FunctionsHeap
    {
        private Dictionary<string, IFunction> _functions;
        private VariablesHeap _variables;


        public FunctionsHeap(VariablesHeap variables)
        {
            _variables = variables;
            _functions = Initialize();
        }

        public void AddFunction(string funcName, IFunction newFunction)
        {    
            _functions[funcName] = newFunction;
        }

        public IFunction GetFunction(string functionName)
        {
            return _functions[functionName];
        }

        private Dictionary<string, IFunction> Initialize()
        {
            Dictionary<string, IFunction> functions = new Dictionary<string, IFunction>();
            functions.Add("Print", new Print(_variables));

            return functions;
        }
    }
}