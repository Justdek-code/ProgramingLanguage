namespace SchoolScript.AST
{
    public interface IMathOperation : ICompound
    {
        string Operation { get; set; }
        ICompound LeftOperand { get; set; }
        ICompound RightOperand { get; set; }
    }
}