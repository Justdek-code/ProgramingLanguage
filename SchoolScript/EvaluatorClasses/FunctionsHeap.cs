using System.Collections.Generic;
using SchoolScript.Functions;


namespace SchoolScript.EvaluatorClasses
{
    public class FunctionsHeap
    {
        private Dictionary<string, Function> _functions;
        private VariablesHeap _variables;


        public FunctionsHeap(VariablesHeap variables)
        {
            _variables = variables;
            _functions = Initialize();
        }

        public void AddFunction(string funcName, Function newFunction)
        {    
            _functions[funcName] = newFunction;
        }

        public Function GetFunction(string functionName)
        {
            return _functions[functionName];
        }

        private Dictionary<string, Function> Initialize()
        {
            Dictionary<string, Function> functions = new Dictionary<string, Function>();
            functions.Add("Print", new Print(_variables));
            functions.Add("ReadInteger", new ReadInteger(_variables));

            return functions;
        }
    }
}