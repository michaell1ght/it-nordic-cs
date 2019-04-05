using System.Collections.Generic;

namespace BracketPositionValidator
{
    class BracketValidSequenceChecker
    {
        char openRoundBracer = '(';
        char openSquareBracer = '[';
        char closeRoundBracer = ')';
        char closeSquareBracer = ']';

        private char[] CharArray;
        Stack<char> bracerStack = new Stack<char>();

        public BracketValidSequenceChecker(char[] charArray)
        {
            CharArray = charArray;
        }

        public bool BracketIsValidSequenceCheck()
        {
            for (int i = 0; i < CharArray.Length; i++)
            {
                if (CharArray[i] == openRoundBracer || CharArray[i] == openSquareBracer)
                {
                    bracerStack.Push(CharArray[i]);
                }

                if (bracerStack.Count == 0 || 
                    (bracerStack.Peek() == openRoundBracer && CharArray[i] != closeRoundBracer) ||
                    (bracerStack.Peek() == openSquareBracer && CharArray[i] != closeSquareBracer))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
