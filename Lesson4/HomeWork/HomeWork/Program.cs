using System;

namespace HomeWork
{
    [Flags]
    enum ContainerVolume
    {
        OneLiter = 0x1,         //00000001
        FiveLiters = 0x1 << 1,  //00000010
        TwentyLiters = 0x1 << 2 //00000100
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            ContainerVolume containerRequired = new ContainerVolume();
            int volume =0;
            int i = 0;
            int oneLiterCount = 0;
            int fiveLiterCount = 0;
            int twentyLiterCount = 0;
            Console.WriteLine("Какой объём сока нужно упаковать?");
            if (double.TryParse(Console.ReadLine(), out double parseResult) && parseResult > 0)
                {
                volume = (int)Convert.ToInt32(Math.Ceiling(parseResult));
                }
            else
            {
                Console.WriteLine($"Введено некорректное число");
                Console.ReadKey();
            }
            while((volume - 20) >= 0)
            {
                volume = volume - 20;
                twentyLiterCount++;
                containerRequired = containerRequired | ContainerVolume.TwentyLiters;
            }
            while((volume - 5) >= 0)
            {
                volume = volume - 5;
                fiveLiterCount++;
                containerRequired = containerRequired | ContainerVolume.FiveLiters;
            }
            while((volume - 1) >= 0)
            {
                volume = volume - 1;
                oneLiterCount++;
                containerRequired = containerRequired | ContainerVolume.OneLiter;
            }
            if((containerRequired & ContainerVolume.TwentyLiters) == ContainerVolume.TwentyLiters)
            {
                Console.WriteLine($"20 л: {twentyLiterCount}");
            }
            if ((containerRequired & ContainerVolume.FiveLiters) == ContainerVolume.FiveLiters)            {
                Console.WriteLine($"5 л: {fiveLiterCount}");
            }            if ((containerRequired & ContainerVolume.OneLiter) == ContainerVolume.OneLiter)
            {
                Console.WriteLine($"1 л: {oneLiterCount}");
            }
            Console.ReadKey();
        }
    }
}
