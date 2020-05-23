using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class String : IString
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set;}
        public string StringValue { get; set; }

        public String(string value)
        {
            Type = ASTType.STRING;
            StringValue = value;
        }
    }
}