using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class If : IStatementIf
    {
        public IEquation Equation { get; set; }
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }

        public If(IEquation equation, List<ICompound> blockStatements)
        {
            Type = ASTType.IF_STATEMENT;
            Equation = equation;
            Leaves = blockStatements;
        }
    }
}