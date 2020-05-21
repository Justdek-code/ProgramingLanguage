using System.Collections.Generic;


namespace SchoolScript
{
    public enum AstType
    {

        COMPOUND,
        VAR_DEFINITION,
        VARIABLE,
        FUNCTION_CALL,
        STRING,
        IDENTIFIER
    }

    public class AST
    {
        public AstType Type { get; set; }
        
        public string VariableName { get; set; } // AST VARIABLE

        public string VariableDefinitionName { get; set;} // AST VARIABLE DEFINITION
        public AST VariableDefinitionValue { get; set; }

        public string FunctionCallName { get; set; } // AST FUNCTION CALL
        public List<AST> FunctionArguments { get; set; }
        public int FunctionArgumentsSize { get; set; }

        public string StringValue { get; set; } // AST STRINGs

        public List<AST> CompoundList { get; set; } // AST COMPOUND
        public int CompoundListLength { get; set; }


        public AST(AstType type)
        {            
            Type = type;
        }

        public AST()
        {
        }
    }
}