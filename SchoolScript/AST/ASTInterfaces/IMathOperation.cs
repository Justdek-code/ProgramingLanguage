using System.Collections.Generic;


namespace SchoolScript.AST
{
    public interface IMathOperation : ICompound
    {
        string Operation { get; set; }
    }
}