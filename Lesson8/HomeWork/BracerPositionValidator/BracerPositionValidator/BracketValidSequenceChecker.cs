using System;
using System.Collections.Generic;

namespace BracketPositionValidator
{
    public class BracketValidSequenceChecker
    {
        private static char openRoundBracer = '(';
        private static char openSquareBracer = '[';
        private static char closeRoundBracer = ')';
        private static char closeSquareBracer = ']';

        private char[] BracketArray;

        public BracketValidSequenceChecker(string inputBracketString)
        {
            if (!(inputBracketString.Contains(openRoundBracer) ||
            inputBracketString.Contains(openSquareBracer) ||
            inputBracketString.Contains(closeRoundBracer) ||
            inputBracketString.Contains(closeSquareBracer)))
            {
                throw new ArgumentOutOfRangeException();
            }

            BracketArray = inputBracketString.ToCharArray();
        }

        public bool BracketIsValidSequenceCheck()
        {
            Stack<char> bracketStack = new Stack<char>();
            foreach (char currentBracket in BracketArray)
            {
                if (currentBracket == openRoundBracer || currentBracket == openSquareBracer)
                {
                    bracketStack.Push(currentBracket);
                    continue;
                }

                if (currentBracket == closeSquareBracer || currentBracket == closeRoundBracer)
                {
                    if (bracketStack.Count > 0)
                    {
                        char lastSymbol = bracketStack.Pop();

                        if (!(currentBracket == closeSquareBracer && lastSymbol == openSquareBracer ||
                            currentBracket == closeRoundBracer && lastSymbol == openRoundBracer))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return bracketStack.Count == 0;
        }
    }
}
