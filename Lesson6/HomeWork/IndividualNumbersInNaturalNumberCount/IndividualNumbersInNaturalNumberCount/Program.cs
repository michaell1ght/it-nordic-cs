using System;

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
            int IndividualNumberscount = 0;
            int currentNaturalNumberIntegerPart = 0;
            Console.WriteLine("Введите натуральное число:");

            try
            {
                naturalNumber = int.Parse(Console.ReadLine());
                if (naturalNumber > 0)
                {
                    currentNaturalNumberIntegerPart = naturalNumber;
                    while (currentNaturalNumberIntegerPart > 0)
                    {
                        if ((currentNaturalNumberIntegerPart % 10) % 2 == 0)
                            IndividualNumberscount++;
                        currentNaturalNumberIntegerPart /= 10;
                    }
                }
                else
                {
                    Console.WriteLine("input value is not a number more than zero");
                    Console.ReadKey();
                    throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine($"Количество чётных цифр числа {naturalNumber} равно { IndividualNumberscount} ");
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
