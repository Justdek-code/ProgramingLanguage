namespace SchoolScript.AST
{
    public interface IStatementIf : ICompound
    {
        ICompound Equation { get; set; }
    }
}