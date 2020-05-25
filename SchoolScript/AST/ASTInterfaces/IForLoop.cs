namespace SchoolScript.AST
{
    public interface IForLoop : ICompound
    {
        int Times { get; set; }
    }
}