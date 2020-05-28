namespace SchoolScript.AST
{
    public interface IWhileLoop : ICompound
    {
        ICompound Equation { get; set; }
    }
}