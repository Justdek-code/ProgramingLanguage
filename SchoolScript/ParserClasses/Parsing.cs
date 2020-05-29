using System;
using System.Collections.Generic;
using SchoolScript.AST;
using SchoolScript.Tokens;


namespace SchoolScript.ParserClasses
{
    public class Parsing
    {
        private List<string> _keywords;
        private List<ICompound> _statements;
        private TokenControl _tokens;


        public Parsing(LexicalAnalazing lexer)
        {
            _tokens = new TokenControl(lexer.GetContent());
            _keywords = InitializeKeywords();
            _statements = ParseStatments();
        }

        public ICompound GetContent()
        {
            return new CompoundTree(_statements);
        }

        private List<ICompound> ParseStatments()
        {
            List<ICompound> statements = new List<ICompound>();

            while (_tokens.GetCurrent().Type == TokenType.IDENTIFIER) 
            {
                if (IsVarDefinition(_tokens.GetCurrent()))
                {
                    statements.Add(new VariableDefinitionParser(_tokens).GetContent());
                }   
                else if (IsVarAssignment())
                {
                    statements.Add(new AssignmentParser(_tokens).GetContent());
                }
                else if (IsKeywordCall(_tokens.GetCurrent()))
                {

                }
                else if (IsFunctionCall())  
                {
                    
                }   
                else
                {
                    throw new NotImplementedException("error: cannot detemine statement type");
                }   

                if (!IsNextStatement())
                {
                    break;
                }

                _tokens.NextToken();
            } 

            return statements;
        }
        
        private bool IsNextStatement()
        {
            if (_tokens.IsNextToken())
            {
                return true;
            }

            return false;
        }

        private bool IsVarDefinition(IToken currentToken)
        {
            if (currentToken.Value == "var")
            {
                return true;
            }

            return false;
        }

        private bool IsFunctionCall()
        {
            if (!_keywords.Contains(_tokens.GetCurrent().Value))
            {
                _tokens.NextToken();
                if (_tokens.GetCurrent().Type == TokenType.LPARENTHESIS)
                {
                    _tokens.PreviousToken();
                    return true;
                }

                _tokens.PreviousToken();
            }

            return false;
        }

        private bool IsKeywordCall(IToken currentToken)
        {
            if (_keywords.Contains(currentToken.Value))
            {
                return true;
            }

            return false;
        }

        private bool IsVarAssignment()
        {
            _tokens.NextToken();
            if (_tokens.GetCurrent().Type == TokenType.ASSIGNMENT)
            {
                _tokens.PreviousToken();
                return true;
            }

            _tokens.PreviousToken();
            return false;
        }

        private List<string> InitializeKeywords()
        {
            List<string> keywords = new List<string>();
            keywords.Add("while");
            keywords.Add("if");

            return keywords;
        }
    }
}