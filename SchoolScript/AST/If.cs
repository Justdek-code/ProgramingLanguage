using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class If : IStatementIf
    {
        public ICompound Equation { get; set; }
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }

        public If(ICompound equation, List<ICompound> ifBlock)
        {
            Type = ASTType.IF_STATEMENT;
            Equation = equation;
            Leaves = ifBlock;
        }
    }
}