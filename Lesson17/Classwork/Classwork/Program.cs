using System;

namespace Classwork
{
	class Program
	{
		static void Main(string[] args)
		{
			var worker = new Worker();

			worker.WorkPerformed += Worker_WorkPerformed;
			worker.WorkCompleted += Worker2_WorkCompleted;

			worker.DoWork(5, WorkType.Work);
			Console.ReadKey();
		}

		private static void Worker2_WorkCompleted(object sender, EventArgs e)
		{
			Console.WriteLine($"Work is done : {sender.GetHashCode()}");
		}

		private static void Worker_WorkPerformed(int hours, WorkType workType)
		{
			Console.WriteLine($"Work of type {workType}: {hours} hours");
		}

		//	WorkPerformedEventHandler delegate1 = WorkPerformed1;
		//	WorkPerformedEventHandler delegate2 = WorkPerformed2;
		//	WorkPerformedEventHandler delegate3 = WorkPerformed3;

		//	delegate1 += delegate2 + delegate3;

		//	int result = delegate1(8, WorktType.DoNothing);
		//	Console.WriteLine(result);
		//	Console.ReadKey();
		//}

		//private static int WorkPerformed1(int hours, WorktType worktType)
		//{
		//	Console.WriteLine($"Workperformed1" + $" :  Work of type {worktType} : {hours} hours");
		//	return hours+1;
		//}

		//private static int WorkPerformed2(int hours, WorktType worktType)
		//{
		//	Console.WriteLine($"Workperformed2" + $" :  Work of type {worktType} : {hours} hours");
		//	return hours + 2;
		//}

		//private static int WorkPerformed3(int hours, WorktType worktType)
		//{
		//	Console.WriteLine($"Workperformed3" + $" :  Work of type {worktType} : {hours} hours");
		//	return hours + 3;
		//}


	}
}
