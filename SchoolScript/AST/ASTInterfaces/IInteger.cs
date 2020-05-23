using System.Collections.Generic;


namespace SchoolScript.AST
{
    public interface IInteger : ICompound
    {
        int IntegerValue { get; set; }
    }
}