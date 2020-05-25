using System.Collections.Generic;
using SchoolScript.AST;


namespace SchoolScript.Tests
{
    public class ParserTest
    {
        public ICompound compound;
        public ParserTest()
        {
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
            

            List<ICompound> blockStatements = new List<ICompound>();
            blockStatements.Add(func);
            Equation equation = new Equation(operands, "==");
            ICompound ifStatement = new If(equation, blockStatements);
            
            statements.Add(ifStatement);
            
            compound = new CompoundTree(statements);
        }
    }
}