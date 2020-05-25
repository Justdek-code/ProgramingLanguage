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
            ICompound assignment = new Assignment("a", new AST.String("Hello World"));
            statements.Add(varDefiniton);
            statements.Add(assignment);

            compound = new CompoundTree(statements);
        }
    }
}