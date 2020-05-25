namespace SchoolScript.AST
{
    public interface IVariableDefinition : ICompound
    {
        string VariableDefinitionName { get; set; }
    }
}