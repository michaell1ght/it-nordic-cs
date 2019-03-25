using System;

namespace OOP
{
	class Program
	{
		static void Main(string[] args)
		{
			Pet pet1 = new Pet();
			pet1.Name = "Котейка";
			pet1.Kind = "Cat";
			pet1.Sex = 'F';
			pet1.Age = 2;

			Console.WriteLine($"{pet1.Description}");
			Pet pet2 = new Pet()
			{
				Name = "Пёска",
				Kind = "Dog",
				Sex = 'M',
				Age = 4
			};

			Console.WriteLine($"{pet2.Description}");
			Console.ReadKey();
		}
	}
}
