using System.Collections.Generic;
using SchoolScript.AST;


namespace SchoolScript.Tests
{
    public class ParserTest
    {
        public ICompound compound;
        public ParserTest()
        {
            List<ICompound> statements = new List<ICompound>();
            ICompound varDefiniton = new VariableDefinition("a", new Integer(5));
            ICompound assignment = new Assignment("a", new Integer(16));

            List<ICompound> arguments = new List<ICompound>();
            IString str = new String("Hello World");
            IVariableCall var = new VariableCall("a");
            Integer n1 = new Integer(5);
            Integer n2 = new Integer(6);
            List<ICompound> operands = new List<ICompound>();
            operands.Add(n1);
            operands.Add(n2);
            ICompound operation = new MathOperation(operands,"*");
            arguments.Add(str);
            arguments.Add(var);
            arguments.Add(operation);
            ICompound funcCall = new FunctionCall(arguments, "Print");

            statements.Add(varDefiniton);
            statements.Add(assignment);
            statements.Add(funcCall);

            compound = new CompoundTree(statements);
        }
    }
}