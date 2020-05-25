namespace SchoolScript.AST
{
    public interface IAssignment : ICompound
    {
        string VariableName { get; set; }
    }
}