namespace SchoolScript.AST
{
    public interface IStatementIf : ICompound
    {
        IEquation Equation { get; set; }
    }
}