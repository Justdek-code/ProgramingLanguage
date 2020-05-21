using System;
using System.Collections.Generic;

/*
namespace SchoolScript
{
    public class Parser
    {
        private TokenControl _tokenControl;
        private TokenType _statementEnd = TokenType.SEMI;

        public Parser(Lexer lexer)
        {
            _tokenControl = new TokenControl(lexer);
        }

        public AST Parse()
        {
            AST compound = new AST(AstType.COMPOUND);
            compound.CompoundList = new List<AST>();
            AST statement = ParseStatement(_tokenControl.GetToken());

            while (statement != null)
            {
                compound.CompoundList.Add(statement);
                compound.CompoundListLength++;
                statement = ParseStatement(_tokenControl.GetToken());  
            }

            return compound;
        }

        private AST ParseStatement(Token token) // parse all statement until ;
        {
            AST statement = null;
            
            if (token.Type == TokenType.ID)
            {
                if (IsVarDefinition())
                {
                    _tokenControl.GoNext(); // pass var
                    statement = ParseVarDefinition();
                }
                else if (IsFunctionCall())
                {
                    statement = ParseFunctionCall();
                }
            }

            return statement;
        }

        private bool IsVarDefinition()
        {
            if (_tokenControl.GetToken().Value == "var")
            {
                _tokenControl.GoNext();

                if (_tokenControl.GetToken().Type == TokenType.ID) // check exsistence of name
                {
                    _tokenControl.GoPrevious();
                    return true;
                }
            }

            return false;
        }
        
        private bool IsFunctionCall()
        {
            _tokenControl.GoNext(); // pass func name token
            if (_tokenControl.GetToken().Type == TokenType.LPARENTHESIS)
            {
                _tokenControl.GoPrevious(); // back to func name token
                return true;
            }

            _tokenControl.GoPrevious();
            return false;
        }

        private AST ParseVarDefinition()
        {
            AST statement = new AST(AstType.VAR_DEFINITION);
            statement.VariableDefinitionName = _tokenControl.GetToken().Value;
            _tokenControl.GoNext();

            //In this version of lang when you declare new var you have to assign value
            if (_tokenControl.GetToken().Type == TokenType.ASSIGNMENT)
            {
                _tokenControl.GoNext(); // pass equal token
                statement.VariableDefinitionValue = ParseExpression();

                CheckStatementEnd(); // if not throw exception
                _tokenControl.GoNext(); //pass semi
            }
            else 
            {
                throw new NotImplementedException("wrong variable definition '=' doesn't exist");
            }

            return statement;
        }

        private AST ParseExpression()
        {
            AST expression = new AST();
            Token currentToken = _tokenControl.GetToken();

            if (currentToken.Type == TokenType.STRING)
            {
                expression.Type = AstType.STRING;
                expression.StringValue = currentToken.Value;
            }
            else 
            {
                throw new NotImplementedException("language doesn't provide this");
            }

            _tokenControl.GoNext();
            return expression;
        }

        private AST ParseFunctionCall()
        {
            AST statement = new AST(AstType.FUNCTION_CALL);
            statement.FunctionCallName = _tokenControl.GetToken().Value;
            statement.FunctionArguments = new List<AST>();
            _tokenControl.GoNext(2);

            Token currentToken = _tokenControl.GetToken();
            while (isFunctionArgument(currentToken))
            {
                statement.FunctionArgumentsSize++;
                AST argument = ParseFunctionArgument(currentToken);
                statement.FunctionArguments.Add(argument);
                _tokenControl.GoNext();

                currentToken = _tokenControl.GetToken();
                if (CheckNextArgument(currentToken))
                {
                    _tokenControl.GoNext(); // pass COMMA
                    currentToken = _tokenControl.GetToken();
                }
                else 
                {
                    _tokenControl.GoNext(); // pass LPARENTHESIS
                    break;
                }
            }
            CheckStatementEnd();

            return statement;
        }
        
        private bool CheckNextArgument(Token currentToken)
        {
            if (currentToken.Type == TokenType.RPARENTHESIS)
            {
                return false;
            }
            else if (currentToken.Type != TokenType.COMMA)
            {
                throw new NotImplementedException("there is no comma between arguments");
            }
            else 
            {
                return true;
            }
        }

        private bool isFunctionArgument(Token token)
        {
            if (token.Type == TokenType.STRING ||
                token.Type == TokenType.ID)
            {
                return true;
            }

            return false;
        }

        private AST ParseFunctionArgument(Token token)
        {
            AST argument = new AST();
            if (token.Type == TokenType.STRING)
            {
                argument.Type = AstType.STRING;
                argument.StringValue = token.Value;
            }
            else if (token.Type == TokenType.ID &&
                    IsFunctionCall() == false)
            {
                argument.Type = AstType.VARIABLE;
                argument.VariableName = token.Value;
            }

            return argument;
        }

        private void CheckStatementEnd()
        {
            Token token = _tokenControl.GetToken();
            if (token.Type != _statementEnd)
            {
                throw new NotImplementedException("there is no ';' in the end of statement");
            }
        }
    }
}
*/