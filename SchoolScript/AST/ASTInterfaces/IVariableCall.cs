using System.Collections.Generic;


namespace SchoolScript.AST
{
    public interface IVariableCall : ICompound
    {
        string VariableName { get; set; }
    }
}