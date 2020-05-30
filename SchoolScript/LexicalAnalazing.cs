using System;
using SchoolScript.Tokens;
using System.Collections.Generic;

namespace SchoolScript
{
    public class LexicalAnalazing 
    {
        private List<IToken> _tokens;
        private int _index;
        private string _content;
        private int _contentLenght;
        private char _currentSymbol;
        private readonly string EQUAL_SIGN = "==";
        private readonly char STRING_DEFINITION = '"';
        private readonly char UNDERLINE = '_';
        private readonly char WHITESPACE = ' ';
        private readonly char NEW_LINE = '\n';


        public LexicalAnalazing(FileReader file)
        {
            _content = file.GetContent();
            _contentLenght = _content.Length;
            _currentSymbol = _content[_index];
            _tokens = ExtractTokens();
        }

        public List<IToken> GetContent()
        {
            return new List<IToken>(_tokens);
        }        

        public void PrintTokens()
        {
            foreach (IToken token in _tokens)
            {
                System.Console.WriteLine($"Token (Type: {token.Type}; Value: \"{token.Value}\")");
            }
        }

        private List<IToken> ExtractTokens()
        {
            List<IToken> tokens = new List<IToken>();

            IToken temp;
            while (_index < _contentLenght)
            {
                if (_currentSymbol == WHITESPACE || _currentSymbol == NEW_LINE)
                {
                    SkipWhitespace();
                    continue;
                }
                else if (Char.IsNumber(_currentSymbol) )
                {
                   temp = CollectNumber(); 
                } 
                else if (Char.IsLetter(_currentSymbol) || _currentSymbol == UNDERLINE)
                {
                    temp = CollectIdentifier();
                    if (IsBoolean(temp))
                    {
                        temp = new Token(TokenType.BOOLEAN, temp.Value);
                    }
                    
                } 
                else if (_currentSymbol == STRING_DEFINITION)
                {
                    temp = CollectString(); 
                } 
                else
                {
                    if (IsEqualSign())
                    {
                        temp = new SyntaxToken(EQUAL_SIGN);
                    }
                    else
                    {
                        temp = new SyntaxToken(_currentSymbol.ToString());
                    }
                    NextSymbol();
                }

                tokens.Add(temp);
            }
        
            return tokens;
        }

        private bool IsEqualSign()
        {
            if (_currentSymbol == '=')
            {
                NextSymbol();
                if (_currentSymbol == '=')
                {
                    return true;
                }
                
                PreviousSymbol();
            }
            
            return false;
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

        private bool IsBoolean(IToken token)
        {
            if (token.Type == TokenType.IDENTIFIER)
            {
                if (token.Value == "true" || token.Value == "false")
                {
                    return true;
                }
            }

            return false;
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
                NextSymbol();
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