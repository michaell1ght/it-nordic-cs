using System;

namespace StringMethods
{
	class Program
	{
		static void Main(string[] args)
		{

			string a = "my test string";
			Console.WriteLine(a.Substring(8, 182));
			Console.ReadKey();
		}
	}
}