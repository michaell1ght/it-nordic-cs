using System;

namespace ClassWork
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            var marks = new[]
			{
			new[] {2,3,3,2,3},
			new[] {2,4,5,3},
			null,
			new[] { 5,5,5,5},
			new[] { 4}
			};
			int i = 0;
			int j = 0;
			int sumByDay=0;
			int sumByWeek=0;
			for (i=0;i<marks[i].Length;i++)
			{
				sumByWeek += marks[i];
				for (j = 0; j < marks[j].Length; j++)
				{
					sumByDay= marks[j];
				}
			}
			Console.ReadKey();
		}
	}
}
//arr1 от 1 до 5 - массив оценок
//arr2 от 1 до 5
