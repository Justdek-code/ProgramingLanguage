using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class MathOperation : IMathOperation
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set;}
        public ICompound LeftOperand { get; set; }
        public ICompound RightOperand { get; set; }
        public string Operation { get; set; }

        public MathOperation(List<ICompound> operands, string operation)
        {
            Type = ASTType.MATH_OPERATION;
            Leaves = operands;
            LeftOperand = Leaves[0];
            RightOperand = Leaves[1];
            Operation = operation;
        }
    }
}