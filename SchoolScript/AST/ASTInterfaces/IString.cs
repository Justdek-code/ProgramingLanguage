using System.Collections.Generic;


namespace SchoolScript.AST
{
    public interface IString : ICompound
    {
        string StringValue { get; set; }
    }
}