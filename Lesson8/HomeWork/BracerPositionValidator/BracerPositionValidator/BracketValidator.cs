using System;
using System.Collections.Generic;
using System.Text;

namespace BracketPositionValidator
{
    class BracketValidator
    {
        public static bool isRoundOrSquareBracket(char bracketChar)
        {
            HashSet<char> roundAndSquarebracerSet = new HashSet<char>()
            {
                '(',
                ')',
                '[',
                ']'
            };
            bool result = false;
            if (roundAndSquarebracerSet.Contains(bracketChar))
            {
                result = true;
            }

            return result;
        }
    }
}
