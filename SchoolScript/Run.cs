using System;
using System.Collections.Generic;
using SchoolScript.Tokens;
using SchoolScript.AST;
using SchoolScript.Tests;
using SchoolScript.EvaluatorClasses;
using SchoolScript.ParserClasses;


namespace SchoolScript
{
    class Run
    {
        static void Main(string[] args)
        {
            string path = "C:\\LangInterpreter\\SchoolScript\\CodeExamples\\calculator.ss";

            new Evaluating(
                new Parsing(
                    new LexicalAnalazing(
                        new FileReader(args[0])
                    )
                )
            ).Run();

        }           
    }
}
