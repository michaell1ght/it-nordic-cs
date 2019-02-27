using System;

namespace ClassWork2
{
	class Program
	{
		static void Main(string[] args)
		{
		Console.WriteLine ("Введите радиус круга");
		float CircleRadius= float.Parse(Console.ReadLine());
		float result = (float) Math.Pow(CircleRadius, 2) *(float)Math.PI;
		Console.WriteLine($"Площадь круга ={result}");
		Console.ReadKey();
		}
	}
}
