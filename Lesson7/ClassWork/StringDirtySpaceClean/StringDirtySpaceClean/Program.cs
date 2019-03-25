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

            Console.WriteLine("Это приложение удалит лишние пробелы в строке и напишет второе слово заглавными буквами");
            Console.WriteLine("Введите строку:");
            string[] inputStringArray = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder formattedString = new StringBuilder();

            for (int i = 0; i< inputStringArray.Length; i++)
            {
                if (i==1)
                {
                    inputStringArray[i]=inputStringArray[i].ToUpper();
                }

                    formattedString.Insert(formattedString.Length, inputStringArray[i]);
                    formattedString.Insert(formattedString.Length, " ");
            }
            
            formattedString.Remove(formattedString.Length -1, 1);
            Console.WriteLine(formattedString);
            Console.ReadKey();
        }
    }
}
