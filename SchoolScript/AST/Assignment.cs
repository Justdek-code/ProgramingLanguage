using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class Assignment : IAssignment
    {
        public string VariableName { get; set; }
        public ASTType Type  { get; set; }
        public List<ICompound> Leaves  { get; set; }


        public Assignment(string variableName, ICompound newValue)
        {
            Type = ASTType.ASSIGNMENT;
            Leaves = new List<ICompound>();
            Leaves.Add(newValue);
            VariableName = variableName;
        }
    }
}