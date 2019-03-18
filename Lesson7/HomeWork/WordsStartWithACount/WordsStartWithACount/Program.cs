using System;

namespace WordsStartWithACount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            const int INPUTWORDSQUANTITY = 2;
            int i = 0;
            int count = 0;
            string outputPhrase = "количество слов начинающихся с русской буквы буквы 'А'";
            string inputString = null;
            string[] inputStringArray = { null };
            const char STRINGTOARRAYSEPARATOR = ' ';
            Console.WriteLine($"Данное приложение считает {outputPhrase} ");
            Console.WriteLine("введите строку");
            inputString = Console.ReadLine();
            inputStringArray = inputString.Split(STRINGTOARRAYSEPARATOR);
            while (String.IsNullOrWhiteSpace(inputString) == true && inputStringArray.Length < INPUTWORDSQUANTITY)
            {
                Console.WriteLine("Ошибка! Нужно ввести хотя бы 2 слова. Попробуйте ещё раз");
                inputString = Console.ReadLine();
                inputStringArray = inputString.Split(STRINGTOARRAYSEPARATOR);
            }
            for (i = 0; i < inputStringArray.Length; i++)
            {
                if (inputStringArray[i].StartsWith("а" ,true, System.Threading.Thread.CurrentThread.CurrentCulture))
                {
                    count++;
                }
            }
            Console.WriteLine($"{SetFirstStringLetterToUpperCase(outputPhrase)} = { count}");
            Console.ReadKey();
        }
        public static string SetFirstStringLetterToUpperCase(string someString)
        {
            return someString = someString.Substring(0, 1).ToUpper() + someString.Substring(1, someString.Length - 1);
        }
    }
}
