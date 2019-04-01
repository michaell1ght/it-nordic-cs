using System;
using System.Collections.Generic;
using System.Text;

namespace BracketPositionValidator
{
    public static class BracketTypeChecker
    {

        public static int isOpenedBracket(char bracketChar)
        {
            int result=0;
            switch (bracketChar)
                {
                case '(':
                    result = (int)BracketType.roundBracer;
                    break;
                case '[':
                    result = (int)BracketType.squareBracer;
                    break;
                //default:
                //    throw new ArgumentOutOfRangeException();
                }
            return result;
        }

        public static int isClosedBracket(char bracketChar)
        {
            int result = 0;
            switch (bracketChar)
            {
                case ')':
                    result = (int)BracketType.roundBracer;
                    break;
                case ']':
                    result = (int)BracketType.squareBracer;
                    break;
                //default:
                //    throw new ArgumentOutOfRangeException();
            }
            return result;
        }
    }
}
