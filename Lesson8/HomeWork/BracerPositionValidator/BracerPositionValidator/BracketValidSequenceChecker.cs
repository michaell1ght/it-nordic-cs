using System;
using System.Collections.Generic;

namespace BracketPositionValidator
{
    public class BracketValidSequenceChecker
    {
        const char openRoundBracket = '(';
        const char openSquareBracket = '[';
        const char closeRoundBracket = ')';
        const char closeSquareBracket = ']';

        private string _bracketString;

        public bool BracketIsValidSequenceCheck(string inputBracketString)
        {
            if (!(inputBracketString.Contains(openRoundBracket) 
                || inputBracketString.Contains(openSquareBracket) 
                || inputBracketString.Contains(closeRoundBracket) 
                || inputBracketString.Contains(closeSquareBracket)))
            {
                throw new ArgumentOutOfRangeException();
            }

            _bracketString = inputBracketString;
            Stack<char> bracketStack = new Stack<char>();

            foreach (char currentBracket in _bracketString.ToCharArray())
            {
                if (currentBracket == openRoundBracket || currentBracket == openSquareBracket)
                {
                    bracketStack.Push(currentBracket);
                    continue;
                }

                if (currentBracket == closeSquareBracket || currentBracket == closeRoundBracket)
                {
                    if (bracketStack.Count > 0)
                    {
                        char lastCheckedBracket = bracketStack.Pop();

                        if (!(lastCheckedBracket == openSquareBracket && currentBracket == closeSquareBracket
                            || lastCheckedBracket == openRoundBracket && currentBracket == closeRoundBracket))
                        {
                            return false;
                        }
                    }
                }
            }

            return bracketStack.Count == 0;
        }
    }
}
