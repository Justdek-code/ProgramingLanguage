using System.Collections.Generic;


namespace SchoolScript.AST
{
    public interface ICompound
    {
        ASTType Type { get; set; }
        List<ICompound> Leaves { get; set;}
    }
}