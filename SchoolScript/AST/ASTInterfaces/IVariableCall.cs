namespace SchoolScript.AST
{
    public interface IVariableCall : ICompound
    {
        string VariableName { get; set; }
    }
}