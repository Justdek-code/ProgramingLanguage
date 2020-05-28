using System.Collections.Generic;


namespace SchoolScript.AST
{
    public enum EquationSign
    {
        LESS,
        BIGGER,
        EQUAL,
        NONE
    }

    public class Equation : IEquation
    {
        public EquationSign Sign { get; set; } 
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }

        public Equation(List<ICompound> operands, EquationSign sign)
        {
            Type = ASTType.EQUATION;
            Leaves = operands;
            Sign = sign;
        }
    }

}