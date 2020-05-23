using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class CompoundTree : ICompound
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }

        public CompoundTree(List<ICompound> statements)
        {
            Type = ASTType.COMPOUND;
            Leaves = statements;
        }
    }
}