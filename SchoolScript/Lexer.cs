using System;
using SchoolScript.Tokens;
using System.Collections.Generic;

namespace SchoolScript
{
    public class Lexer 
    {
        private List<IToken> _tokens;
        private int _index;
        private string _content;
        private int _contentLenght;
        private char _currentSymbol;
        private readonly char STRING_DEFINITION = '"';
        private readonly char UNDERLINE = '_';
        private readonly char WHITESPACE = ' ';
        private readonly char NEW_LINE = '\n';


        public Lexer(string content)
        {
            _contentLenght = content.Length;
            _content = content;
            _currentSymbol = _content[_index];
            _tokens = ExtractTokens();
        }

        public List<IToken> GetContent()
        {
            return new List<IToken>(_tokens);
        }        

        private List<IToken> ExtractTokens()
        {
            List<IToken> tokens = new List<IToken>();

            while (_index < _contentLenght)
            {
                if (_currentSymbol == WHITESPACE || _currentSymbol == NEW_LINE)
                {
                    SkipWhitespace();
                }
                else if (Char.IsNumber(_currentSymbol) )
                {
                    IToken numberToken = CollectNumber();
                    tokens.Add(numberToken);
                }
                else if (Char.IsLetter(_currentSymbol) || _currentSymbol == UNDERLINE )
                {
                    IToken identifierToken = CollectIdentifier();
                    tokens.Add(identifierToken);
                }
                else if (_currentSymbol == STRING_DEFINITION)
                {
                    IToken stringToken = CollectString();
                    tokens.Add(stringToken);
                }
                else
                {
                    IToken syntaxToken = new SyntaxToken(_currentSymbol.ToString());
                    tokens.Add(syntaxToken);
                    NextSymbol();
                }
            }
        
            return tokens;
        }

        private void NextSymbol(int step = 1)
        {
            _index += step;
            if (_index < _contentLenght)
            {
                _currentSymbol = _content[_index];
            }
        }

        private void PreviousSymbol(int step = 1)
        {
            _index -= step;
            if (_index >= 0)
            {
                _currentSymbol = _content[_index];
            }
        }

        private void SkipWhitespace()
        {
            NextSymbol();

            while (_currentSymbol == WHITESPACE)
            {
                NextSymbol();
            }
        }

        private IToken CollectNumber()
        {
            string number = _content[_index].ToString();

            NextSymbol();
            while (Char.IsNumber(_content[_index]) )
            {
                number += _content[_index];
            }

            return new Token(TokenType.NUMBER, number);
        }

        private IToken CollectIdentifier()
        {
            
            string identifier = _currentSymbol.ToString();
            NextSymbol();

            while (Char.IsLetterOrDigit(_currentSymbol))
            {
                identifier += _currentSymbol;
                NextSymbol();
            }

            return new Token(TokenType.IDENTIFIER, identifier);
        }

        private IToken CollectString()
        {
            NextSymbol();
            string stringValue = String.Empty;

            while (_currentSymbol != STRING_DEFINITION)
            {
                stringValue += _currentSymbol;
                NextSymbol();
            }

            NextSymbol();
            return new Token(TokenType.STRING, stringValue);
        }
    }
}