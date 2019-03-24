using System;

namespace ToLowerCaseAndReverseString
{
    class Program
    {
        public static void Main(string[] args)
        {
            const char stringToArraySeparator = ' ';
            const int inputStringLength= 2;
            
            int i = 0;
            char[] reverseSymbolsArray;
            string inputString = null;
            string[] inputStringArray = {null};

            Console.WriteLine("Данное приложение приводит строку к нижнему регистру и записывает введённую строку в обратном порядке");
            Console.WriteLine("Введите строку");
            inputString = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(inputString)
                || IsLetterOrDigitIgnoreWhitespaceCheck(inputString)
                || inputString.ToCharArray().Length < inputStringLength == true)
            {
                Console.WriteLine("Ошибка! Нужно ввести 2 числа или 2 буквы. Попробуйте ещё раз");
                inputString = Console.ReadLine();
            }

            Array.Reverse(inputStringArray = inputString.ToLower().Split(stringToArraySeparator));
                for (i = 0; i < inputStringArray.Length; i++)
                {
                    reverseSymbolsArray = inputStringArray[i].ToCharArray();
                    Array.Reverse(reverseSymbolsArray);
                    string reverseString = new string(reverseSymbolsArray);
                Console.Write($"{reverseString} ");
                }
                
                Console.ReadKey();
        }

        public static bool IsLetterOrDigitIgnoreWhitespaceCheck(string someString)
        {
            bool result = false;
            char[] inputStringToCharArray = someString.ToCharArray();
            for (int j = 0; j < inputStringToCharArray.Length; j++)
            {
                    if (!Char.IsLetterOrDigit(inputStringToCharArray[j]) && !Char.IsWhiteSpace(inputStringToCharArray[j]))
                    {
                        result = true;
                    }
            
            }
            
            return result;
        }
    }
}
