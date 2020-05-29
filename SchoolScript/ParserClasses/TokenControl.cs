using System;
using SchoolScript.Tokens;
using System.Collections.Generic;


namespace SchoolScript.ParserClasses
{
    public class TokenControl
    {
        private List<IToken> _tokens;
        private IToken _currentToken;
        private int _index;


        public TokenControl(List<IToken> tokens)
        {
            _tokens = tokens;
            _currentToken = _tokens[_index];
        }

        public IToken GetCurrent()
        {
            return _currentToken;
        }

        public bool IsNextToken(int step = 1)
        {
            if (_index + step < _tokens.Count)
            {
                return true;
            }
            
            return false;
        }

        public void NextToken(int step = 1)
        {
            _index += step;

            if (_index  >= _tokens.Count)
            {
                throw new NotImplementedException("error: index is out of range");
            }
            _currentToken = _tokens[_index];
        }

        public void PreviousToken(int step = 1)
        {
            _index -= step;

            if (_index < 0)
            {
                throw new NotImplementedException("error: index is out of range");
            }
            _currentToken = _tokens[_index];
        }
    }
}