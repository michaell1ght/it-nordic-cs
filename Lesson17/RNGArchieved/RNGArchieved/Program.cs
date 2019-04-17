using System;

namespace RNGArchieved
{
	class Program
	{
		static void Main(string[] args)
		{
			RandomDataGenerator rdg = new RandomDataGenerator();
			rdg.GetRandomData(100, 10);
			// положить результат GetRandomData в файл.
		}
	}
}

	//var worker = new Worker();

	//		worker.WorkPerformed += Worker_WorkPerformed;
	//		worker.WorkCompleted += Worker2_WorkCompleted;

	//		worker.DoWork(5, WorkType.Work);
	//		Console.ReadKey();
	//	}

	//private static void Worker2_WorkCompleted(object sender, EventArgs e)
	//{
	//	Console.WriteLine($"Work is done : {sender.GetHashCode()}");
	//}

	//private static void Worker_WorkPerformed(int hours, WorkType workType)
	//{
	//	Console.WriteLine($"Work of type {workType}: {hours} hours");
	//}

