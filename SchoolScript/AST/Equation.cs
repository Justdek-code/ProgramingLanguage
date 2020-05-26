using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class Equation : IEquation
    {
        public string Sign { get; set; } //note
        public ICompound LeftOperand { get; set; }
        public ICompound RightOperand { get; set; }
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }

        public Equation(List<ICompound> operands, string sign)
        {
            Type = ASTType.EQUATION;
            Leaves = operands;
            LeftOperand = Leaves[0];
            RightOperand = Leaves[1];
            Sign = sign;
        }
    }

}