using System.Collections.Generic;
using SchoolScript.AST;


namespace SchoolScript.InlineFunctions
{
    public interface IFunction
    {
        void Invoke(List<ICompound> arguments);
    }
}