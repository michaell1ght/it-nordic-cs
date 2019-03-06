using System;

namespace ClassWork
{
	class Program
	{
		static void Main(string[] args)
		{
			int i = 0;
			Console.WriteLine("введите число");
			try
			{
				i = int.Parse(Console.ReadLine());
				Console.WriteLine(i < 0 ? "отрицательное" : "неотрицателньое");
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.GetType()} , {e.Message}");
			}
			Console.ReadLine();
		}
	}
}