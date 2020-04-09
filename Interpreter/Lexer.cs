using System;
using System.Collections.Generic;

namespace Interpreter
{
    public class Lexer 
    {
        private const char STRING_SIGN = '"';
        private const char UNDERLINE = '_';
        private const char WHITESPACE = ' ';
        private const char NEXT_LINE = '\n';

        private char _currentSymbol;
        private int _index;
        private string _content;
        private int _contentLength;
        private Token _token;

        public Lexer(string content)
        {
            _content = content;
            _currentSymbol = _content[_index];
            _contentLength = _content.Length;

            NextToken();
        }

        public Token GetToken()
        {
            return _token;
        }

        public void NextToken()
        {
            string CurrentSymbolString = _currentSymbol.ToString();

            if (_index >= _contentLength) 
            {
                _token = null;
                return;
            }

            if (_currentSymbol == WHITESPACE || _currentSymbol == NEXT_LINE) 
            {
                SkipWhitespace();
            }
            else if (Char.IsLetter(_currentSymbol))
            {
                CollectIdentifierToken();  
            }
            else if (_currentSymbol == STRING_SIGN)
            {
                CollectStringToken();
            }
            else
            {
                _token = new Token(_currentSymbol, CurrentSymbolString);
                NextSymbol();
            }
        }

        private void NextSymbol()
        {
            _index++;

            if (_index < _contentLength)
            {
                _currentSymbol = _content[_index];
            }
        }

        private void CollectStringToken()
        {
            string stringValue = String.Empty;
            
            NextSymbol();
            while (_currentSymbol != STRING_SIGN)
            {
                stringValue += _currentSymbol.ToString();
                NextSymbol();
            }

            NextSymbol();
            _token = new Token(TokenType.STRING, stringValue);

        }

        private void CollectIdentifierToken()
        {
            string identifierValue = String.Empty;

            do 
            {
                identifierValue += _currentSymbol.ToString();
                NextSymbol();

            } while(Char.IsLetterOrDigit(_currentSymbol) || _currentSymbol == UNDERLINE);

            _token = new Token(TokenType.ID, identifierValue);
        }

        private void SkipWhitespace()
        {
            while (_currentSymbol == WHITESPACE)
            {
                NextSymbol();
            }
            NextToken();
        }
    }
}