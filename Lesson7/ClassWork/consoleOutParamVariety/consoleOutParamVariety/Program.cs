using System;

namespace ClassWork7
{
	class Program
	{
		static void Main(string[] args)
		{
			double a = 0;
			double b = 0;
			Console.WriteLine("введите дробное число 1");
			a = double.Parse(Console.ReadLine());
			Console.WriteLine("введите дробное число 2");
			b = double.Parse(Console.ReadLine());
			double c = a * b;
			//2 знака после запятой
			Console.WriteLine(a + " + " + b +" = " + (a + b));
			Console.WriteLine("{0:#.##} + {1:#.##} = {2:#.##}", a , b, a + b);
			Console.WriteLine($"{a:#.##} - {b:#.##} = {a - b:#.##}");
			Console.ReadKey();
		}
	}
}
