using System;
using System.Text;

namespace StringDirtySpaceClean
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;

            string[] inputString = null;
            StringBuilder sbInputString = new StringBuilder();
            Console.WriteLine("Это приложение удалит лишние пробелы в строке и напишет второе слово заглавными буквами");
            Console.WriteLine("Введите строку:");
            inputString = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i< inputString.Length; i++)
            {
                if (i==1)
                {
                    inputString[i]=inputString[i].ToUpper();
                }

                    sbInputString.Insert(sbInputString.Length, inputString[i]);
                    sbInputString.Insert(sbInputString.Length, " ");
            }

            Console.WriteLine(sbInputString);
            Console.ReadKey();
        }
    }
}
