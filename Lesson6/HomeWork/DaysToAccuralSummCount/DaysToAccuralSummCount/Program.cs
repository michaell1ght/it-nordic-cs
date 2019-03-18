using System;

namespace DaysToAccuralSummCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;

            double currentSumm = 0;
            double startInvestition = 0;
            double expectedSumm = 0;
            double percent = 0;
            int daysCount = 0;

            Console.WriteLine("Введите сумму первоначального взноса в рублях:");
            if (double.TryParse(Console.ReadLine(), out double startInvestitionInput) && startInvestitionInput > 0)
            {
                startInvestition = startInvestitionInput;
            }

            else
            {
                Console.WriteLine("input value is not a number more than zero");
                Console.ReadKey();
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine("Введите ежедневный процент дохода в виде десятичной дроби:");
            if (double.TryParse(Console.ReadLine(), out double percentInput) && percentInput > 0 && percentInput < 1)
            {
                percent = percentInput;
            }

            else
            {
                Console.WriteLine("input value is not a number more than zero and less by one");
                Console.ReadKey();
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine("Введите желаемую сумму накопления в рублях:");
            if (double.TryParse(Console.ReadLine(), out double expectedSummInput) && expectedSummInput > 0)
            {
                expectedSumm = expectedSummInput;
            }

            else
            {
                Console.WriteLine("input value is not a number more than zero");
                Console.ReadKey();
                throw new ArgumentOutOfRangeException();
            }

            currentSumm = startInvestition;
            while(currentSumm < expectedSumm)
            {
                currentSumm += currentSumm * percent;
                daysCount++;
            }

            Console.WriteLine($"Необходимое количество дней для накопления желаемой суммы: {daysCount}");
            Console.ReadKey();
        }
    }
}
