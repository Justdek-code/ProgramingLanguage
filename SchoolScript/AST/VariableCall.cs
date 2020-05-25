using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class VariableCall : IVariableCall
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set;}
        public string VariableName { get; set; }

        public VariableCall(string variableName)
        {
            Type = ASTType.VARIABLE_CALL;
            VariableName = variableName;
            Leaves = new List<ICompound>();
        }
    }
}