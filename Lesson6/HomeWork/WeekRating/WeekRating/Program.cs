using System;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int i = 0;
            int j = 0;
            int summaryDayMark = 0;
            double averageDayMark = 0;
            double summaryAverageWeekMark = 0;
            const string outputText = "The average mark for";
            int markCount=0;
            var marks = new[]
            {
                new [] { 2, 3, 3, 2, 3}, // Monday (it was a good weekend :)
                new [] { 2, 4, 5, 3}, // Tuesday (anyway better than Monday)
                null, // Wednesday (felt sick, stayed at home :( )
                new [] { 5, 5, 5, 5}, // Thursday (God Mode :)
                new [] { 4 } // Friday (Very short day)
            };
            for (i = 0; i < marks.Length; i++)
            {
                if (marks[i] == null)
                {
                    Console.WriteLine("{0} day {1} is N/A ", outputText, i +1 );
                    i++;
                }
                for (j = 0; j < marks[i].Length; j++)
                {
                    summaryDayMark += marks[i][j];
                }
                markCount += j;
                averageDayMark = (double)summaryDayMark / j;
                summaryAverageWeekMark += summaryDayMark;
                summaryDayMark = 0;
                Console.WriteLine(" The average mark for day {0} is {1} ", i + 1, averageDayMark);
            }
            summaryAverageWeekMark = (double)summaryAverageWeekMark / markCount;
            Console.WriteLine("{0} all the week is {0:0.#}", outputText, summaryAverageWeekMark);
            Console.ReadKey();
        }
    }
}