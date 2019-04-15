using System;
using System.Collections.Generic;
using System.Text;

namespace BracketPositionValidator
{
    public static class BracketCheckByExample
    {
        public static void doCheck()
            {
            string bracketString1 = "()";
            string bracketString2 = "[]()";
            string bracketString3 = "[[]()]";
            string bracketString4 = "([([])])()[]";
            string bracketString5 = "(";
            string bracketString6 = "[][)";
            string bracketString7 = "[(])";
            string bracketString8 = "(()[]]";

            BracketValidSequenceChecker bracketChecker1 = new BracketValidSequenceChecker(bracketString1);
            BracketValidSequenceChecker bracketChecker2 = new BracketValidSequenceChecker(bracketString2);
            BracketValidSequenceChecker bracketChecker3 = new BracketValidSequenceChecker(bracketString3);
            BracketValidSequenceChecker bracketChecker4 = new BracketValidSequenceChecker(bracketString4);
            BracketValidSequenceChecker bracketChecker5 = new BracketValidSequenceChecker(bracketString5);
            BracketValidSequenceChecker bracketChecker6 = new BracketValidSequenceChecker(bracketString6);
            BracketValidSequenceChecker bracketChecker7 = new BracketValidSequenceChecker(bracketString7);
            BracketValidSequenceChecker bracketChecker8 = new BracketValidSequenceChecker(bracketString8);

            string[] bracketStringArray = new string[]
            {
                bracketString1,
                bracketString2,
                bracketString3,
                bracketString4,
                bracketString5,
                bracketString6,
                bracketString7,
                bracketString8
            };

            BracketValidSequenceChecker[] bracketCheckerArray = new BracketValidSequenceChecker[]
            {
                bracketChecker1,
                bracketChecker2,
                bracketChecker3,
                bracketChecker4,
                bracketChecker5,
                bracketChecker6,
                bracketChecker7,
                bracketChecker8
            };

            Console.WriteLine("This programm do check the bracket string with the logic, shown in the examples below");

            for (int i =0; i < bracketCheckerArray.Length; i++)
            {
                if (!bracketCheckerArray[i].BracketIsValidSequenceCheck())
                {
                    Console.WriteLine($"Brackets in {bracketStringArray[i]} are not correct");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Brackets in {bracketStringArray[i]} are correct");
                    Console.WriteLine();
                }
            }
        }
    }
}
