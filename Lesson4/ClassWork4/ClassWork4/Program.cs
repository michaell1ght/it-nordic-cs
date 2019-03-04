using System;
using static System.Math;
namespace ClassWork4
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.InputEncoding = System.Text.Encoding.Unicode;
			Console.OutputEncoding = System.Text.Encoding.Unicode;
			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
			System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
			Console.WriteLine("Введите длину стороны");
			long a = long.Parse(Console.ReadLine());
			Console.WriteLine("Введите высоту стороны");
			long h = long.Parse(Console.ReadLine());
			Console.WriteLine($"S бок = {3 * a * h}");
			Console.WriteLine($"S полн = {(3 / (double)2) * a * (a * Math.Sqrt(3) + (2 * h))}");
			Console.WriteLine($"V = {(Math.Pow(a,2) / 2) * (h / Math.Sqrt(2)) * Sqrt(3)}");
			Console.ReadKey();
		}
	}
}
