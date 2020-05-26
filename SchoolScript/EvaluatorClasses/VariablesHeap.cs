using System.Collections.Generic;
using System;


namespace SchoolScript.EvaluatorClasses
{
    public class VariablesHeap
    {
        private Dictionary<string, Variable> _heap;


        public VariablesHeap()
        {
            _heap = new Dictionary<string, Variable>();
        }

        public Variable GetVariable(string varName)
        {
            if (!_heap.ContainsKey(varName))
            {
                throw new NotImplementedException($"error: '{varName}' is not defined");
            }
            
            return _heap[varName];
        }

        public void AddVariable(string name, Variable value)
        {
            if (!_heap.ContainsKey(name))
            {
                _heap.Add(name, value);
            }
            else
            {
                _heap[name] = value;
            }
        }

        public void DeleteVariable(string varName)
        {
            if (_heap.ContainsKey(varName))
            {
                _heap.Remove(varName);
            }
        }
    }
}