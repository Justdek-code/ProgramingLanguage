namespace SchoolScript.AST
{
    public interface IMathOperation : ICompound
    {
        string Operation { get; set; }
    }
}