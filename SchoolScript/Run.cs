using System;
using System.Collections.Generic;
using SchoolScript.Tokens;
using SchoolScript.AST;

namespace SchoolScript
{
    class Run
    {
        static void Main(string[] args)
        {
            string code = "var a = 1 + 1; \nprint(a,\"I'm script\");";
            Lexer lexer = new Lexer(code);
            foreach (IToken token in lexer.GetContent())
            {
                System.Console.WriteLine($"Token (Type: {token.Type}; Value: \"{token.Value}\")");
            }

            Integer num1 = new Integer(1);
            Integer num2 = new Integer(1);
            List<ICompound> operands = new List<ICompound>();
            operands.Add(num1);
            operands.Add(num2);
            MathOperation operation = new MathOperation(operands, "+");
            VariableDefinition varDefiniton = new VariableDefinition(operation, "a");

            List<ICompound> arguments = new List<ICompound>();
            AST.String str = new AST.String("I'm script");
            VariableCall variable = new VariableCall("a");
            arguments.Add(str);
            arguments.Add(variable);
            FunctionCall func = new FunctionCall(arguments, "print");

            List<ICompound> statements = new List<ICompound>();
            statements.Add(varDefiniton);
            statements.Add(func);
            CompoundTree compound = new CompoundTree(statements);
        }           
    }
}
