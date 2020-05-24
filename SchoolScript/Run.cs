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
            string path = "C:\\LangInterpreter\\SchoolScript\\CodeExamples\\example1.ss";

            new Lexer(
                new FileReader(path)
            ).PrintTokens();


            ICompound num1 = new Integer(1);
            ICompound num2 = new Integer(1);
            List<ICompound> operands = new List<ICompound>();
            operands.Add(num1);
            operands.Add(num2);
            ICompound operation = new MathOperation(operands, "+");
            ICompound varDefiniton = new VariableDefinition(operation, "a");

            List<ICompound> arguments = new List<ICompound>();
            ICompound str = new AST.String("I'm script");
            ICompound variable = new VariableCall("a");
            arguments.Add(str);
            arguments.Add(variable);
            ICompound func = new FunctionCall(arguments, "print");

            List<ICompound> statements = new List<ICompound>();
            statements.Add(varDefiniton);
            statements.Add(func);
            ICompound compound = new CompoundTree(statements);
        }           
    }
}
