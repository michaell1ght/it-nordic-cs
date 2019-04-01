using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDataInFourYears
{
    static class InputDataValidator
    {
        const int maxAge = 200;
        public static bool IsLetter(string someString)
        {
            bool result = false;
            char[] charArray = someString.ToCharArray();
            foreach (char arrayElememt in charArray)
            {
                if (Char.IsLetter(arrayElememt))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsCorrectAge(int inputInt)
        {
            bool result = true;
            if (inputInt <=0 || inputInt > maxAge)
            {
                result = false;
            }
            return result;
        }
    }
}