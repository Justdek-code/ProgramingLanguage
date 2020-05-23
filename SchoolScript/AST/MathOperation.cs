using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class MathOperation : IMathOperation
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set;}
        public string Operation { get; set; }

        public MathOperation(List<ICompound> operands, string operation)
        {
            Type = ASTType.MATH_OPERATION;
            Leaves = operands;
            Operation = operation;
        }
    }
}