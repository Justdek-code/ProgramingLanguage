using System.Collections.Generic;


namespace SchoolScript.AST
{
    public interface IFunctionCall : ICompound
    {
        string FunctionName { get; set; }
        int ArgumentsSize{ get; set; }
    }
}