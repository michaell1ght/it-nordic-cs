
using System;

namespace ClassWorkApp
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] arr = new string[5];
			int i = 0;
			for (i = 0; i < arr.Length; i++)
			{
				Console.WriteLine($"input {i + 1} value");
				arr[i] = Console.ReadLine();
			}
			for (i = 0; i < arr.Length; i++)
			{
				Console.WriteLine($"value number {i + 1} = {arr[i]}");
			}
			Console.ReadKey();
		}
	}
}