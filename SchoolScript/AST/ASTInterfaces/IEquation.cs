namespace SchoolScript.AST
{
    public interface IEquation : ICompound
    {
        EquationSign Sign { get; set; }
    }
}