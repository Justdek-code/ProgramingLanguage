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
            ICompound varDefiniton = new VariableDefinition("a", operation);

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

            List<ICompound> loopBlock = new List<ICompound>();
            loopBlock.Add(func);
            ICompound forLoop = new ForLoop(5, loopBlock);
            
            statements.Add(ifStatement);
            statements.Add(forLoop);
            
            ICompound newValueAssignment = new Assignment("a", new Integer(0));
            statements.Add(newValueAssignment);

            compound = new CompoundTree(statements);
        }
    }
}