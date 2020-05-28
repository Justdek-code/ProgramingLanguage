using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class WhileLoop : IWhileLoop
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }
        public ICompound Equation { get; set; }


        public WhileLoop(ICompound equation, List<ICompound> loopBlock)
        {
            Type = ASTType.WHILE_LOOP;
            Equation = equation;
            Leaves = loopBlock;
        }
    }
}