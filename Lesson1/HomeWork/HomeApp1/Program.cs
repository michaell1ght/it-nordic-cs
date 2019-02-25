using System;
using System.Threading;

namespace DemoApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Thread.Sleep(5000);
            Console.WriteLine($"Здравствуйте, {name}");
            Thread.Sleep(5000);
            Console.WriteLine($"Прощайте, {name}");
            Console.ReadKey();
        }
    }
}
