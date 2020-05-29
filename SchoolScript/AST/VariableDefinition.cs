using System.Collections.Generic;

namespace SchoolScript.AST
{
    public class VariableDefinition : IVariableDefinition
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }
        public string VariableDefinitionName { get; set; }

        public VariableDefinition(string variableName, ICompound initialization)
        {   
            Type = ASTType.VAR_DEFINITION;
            
            Leaves = new List<ICompound>();
            ICompound varInitialization = initialization; 
            Leaves.Add(varInitialization);
            VariableDefinitionName = variableName;
        }
    }
}