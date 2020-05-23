using System.Collections.Generic;

namespace SchoolScript.AST
{
    public class VariableDefinition : IVariableDefinition
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }
        public string VariableDefinitionName { get; set; }

        public VariableDefinition(ICompound value, string variableName)
        {
            Leaves = new List<ICompound>();
            Leaves.Add(value);
            Type = ASTType.VAR_DEFINITION;
            VariableDefinitionName = variableName;
        }
    }
}