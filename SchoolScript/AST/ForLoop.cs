using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class ForLoop : IForLoop
    {
        public int Times { get; set; }
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }


        public ForLoop(int times, List<ICompound> loopBlock)
        {
            Type = ASTType.FOR_LOOP;
            Times = times;
            Leaves = loopBlock;
        }
    }
}