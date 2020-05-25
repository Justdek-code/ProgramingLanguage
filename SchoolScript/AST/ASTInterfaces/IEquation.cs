namespace SchoolScript.AST
{
    public interface IEquation : ICompound
    {
        string Sign { get; set; }
        ICompound LeftOperand { get; set; }
        ICompound RightOperand { get; set; }
    }
}