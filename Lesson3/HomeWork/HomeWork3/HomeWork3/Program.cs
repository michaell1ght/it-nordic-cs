using System;
using static System.Net.Mime.MediaTypeNames;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            string[] namearr = new string[3];
            int[] agearr = new int[3];
            int i;
            for (i = 0; i < namearr.Length; i++)
            {
                Console.WriteLine($"Write name of the person {i + 1}");
                namearr[i]=Console.ReadLine();
                foreach (char c in namearr[i])
                {
                    if (Char.IsNumber(c))
                    {
                        Console.WriteLine(new FormatException("the value of parameter name must not contain number"));
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            Console.WriteLine($"Write age of the person {namearr[i]}");
                if (int.TryParse(Console.ReadLine(), out int parseResult))
                {
                    agearr[i] = parseResult;
                }
                else
                {
                Console.WriteLine(new FormatException("the value of parameter age must be integer"));
                Console.ReadKey();
                Environment.Exit(0);
                }
            }
            Console.WriteLine(Environment.NewLine);
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine($"Name: {namearr[i]}, age in 4 years: {agearr[i] + 4}");
            }
            Console.ReadKey();
        }
    }
}