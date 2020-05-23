using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class Integer : IInteger
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set;}
        public int IntegerValue { get; set; }

        public Integer(int value)
        {
            Type = ASTType.INTEGER;
            IntegerValue = value;
        }
    }
}