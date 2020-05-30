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
            string path = "C:\\LangInterpreter\\SchoolScript\\CodeExamples\\example1.ss";

            var reader = new FileReader(path);
            var lexer = new LexicalAnalazing(reader);
            lexer.PrintTokens();
            var parser = new Parsing(lexer);


            ParserTest parserTest = new ParserTest();
            Evaluating evaluator = new Evaluating(parserTest.compound);

        }           
    }
}
