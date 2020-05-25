using System;
using System.Collections.Generic;
using SchoolScript.AST;
using SchoolScript.Tokens;

namespace SchoolScript
{

    public class Evaluator
    {
        private ICompound _compound;
        private Dictionary<string, int> _intVariableHeap;
        private Dictionary<string, string> _stringVariableHeap;


        public Evaluator(ICompound compound) // it future it will takes parser object 
        {
            _compound = compound;
            _intVariableHeap = new Dictionary<string, int>();
            _stringVariableHeap = new Dictionary<string, string>();
        }
    }
}