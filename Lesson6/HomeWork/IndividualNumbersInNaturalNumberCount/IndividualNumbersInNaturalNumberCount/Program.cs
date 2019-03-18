using System;
using System.Collections.Generic;

namespace IndividualNumbersInNaturalNumberCount
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;

            int naturalNumber =0;
            var oddDigitsCollection = new HashSet<int> () { 1, 3, 5, 7, 9 };
            int evenDigitsCount = 0;
            int currentEvenDigitIntegerPart = 0;
            Console.WriteLine("Введите натуральное число:");

            try
            {
                naturalNumber = int.Parse(Console.ReadLine());
                if (naturalNumber > 0)
                {
                    currentEvenDigitIntegerPart = naturalNumber;
                    while (currentEvenDigitIntegerPart > 0)
                    {
                        if (!oddDigitsCollection.Contains((currentEvenDigitIntegerPart % 10)))
                            evenDigitsCount++;
                        currentEvenDigitIntegerPart /= 10;
                    }
                }
                else
                {
                    Console.WriteLine("input value is not a number more than zero");
                    Console.ReadKey();
                    throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine($"Количество чётных цифр числа {naturalNumber} равно { evenDigitsCount} ");
                Console.ReadKey();
            }

            catch (FormatException e)
            {
                Console.WriteLine($"{e.GetType()} , {e.Message}");
                Console.ReadKey();
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"{e.GetType()} , {e.Message}");
                Console.ReadKey();
            }
        }
    }
}
