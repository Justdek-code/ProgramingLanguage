using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class Boolean : IBoolean
    {
        public bool BooleanValue { get; set; }
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }


        public Boolean(bool value)
        {
            Type = ASTType.BOOLEAN;
            Leaves = new List<ICompound>();
            BooleanValue = value;
        }
    }
}