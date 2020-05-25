using System;
using System.Collections.Generic;
using SchoolScript.Tokens;
using SchoolScript.AST;
using SchoolScript.Tests;
using SchoolScript.EvaluatorClasses;

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


            ParserTest parserTest = new ParserTest();
            Evaluator evaluator = new Evaluator(parserTest.compound);
            evaluator.Execute();
        }           
    }
}
