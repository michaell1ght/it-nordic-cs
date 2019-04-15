using System;

namespace ClassWork16
{
	class Program
	{
		static void Main(string[] args)
		{
			CalculateFigureProperty figure = new CalculateFigureProperty(4.5);
			
			Console.WriteLine(figure.Calculate((double perimeter) => (2 * Math.PI * figure.Radius)));
			Console.WriteLine(figure.Calculate((double square) => (Math.PI * Math.Pow(figure.Radius, 2))));

			Console.ReadKey();
		}

		delegate int Operation(double radius);
	}
}