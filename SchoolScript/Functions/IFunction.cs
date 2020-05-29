using System.Collections.Generic;
using SchoolScript.AST;


namespace SchoolScript.Functions
{
    public interface IFunction
    {
        void Invoke(List<ICompound> arguments);
    }
}