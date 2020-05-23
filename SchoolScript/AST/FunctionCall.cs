using System.Collections.Generic;


namespace SchoolScript.AST
{
    public class FunctionCall : IFunctionCall
    {
        public ASTType Type { get; set; }
        public List<ICompound> Leaves { get; set; }
        public string FunctionName { get; set; }
        public int ArgumentsSize { get; set; }

        public FunctionCall(List<ICompound> arguments, string functionName)
        {
            Type = ASTType.FUNCTION_CALL;
            Leaves = arguments;
            ArgumentsSize = arguments.Count;
            FunctionName = functionName;
        }
    }
}