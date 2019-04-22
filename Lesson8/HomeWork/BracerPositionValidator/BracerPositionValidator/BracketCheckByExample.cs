using System;
using System.Collections.Generic;
using System.Text;

namespace BracketPositionValidator
{
    public class BracketCheckByExample
    {
        public void doBracketCheck(string successMessage, string failMessage)
            {
            string bracketString1 = "()";
            string bracketString2 = "[]()";
            string bracketString3 = "[[]()]";
            string bracketString4 = "([([])])()[]";
            string bracketString5 = "(";
            string bracketString6 = "[][)";
            string bracketString7 = "[(])";
            string bracketString8 = "(()[]]";

            BracketValidSequenceChecker bracketChecker1 = new BracketValidSequenceChecker();
            BracketValidSequenceChecker bracketChecker2 = new BracketValidSequenceChecker();
            BracketValidSequenceChecker bracketChecker3 = new BracketValidSequenceChecker();
            BracketValidSequenceChecker bracketChecker4 = new BracketValidSequenceChecker();
            BracketValidSequenceChecker bracketChecker5 = new BracketValidSequenceChecker();
            BracketValidSequenceChecker bracketChecker6 = new BracketValidSequenceChecker();
            BracketValidSequenceChecker bracketChecker7 = new BracketValidSequenceChecker();
            BracketValidSequenceChecker bracketChecker8 = new BracketValidSequenceChecker();

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

            Console.WriteLine("This programm do check the bracket string balance with the logic, shown in the examples below");

            for (int i =0; i < bracketCheckerArray.Length; i++)
            {
                if (!bracketCheckerArray[i].BracketIsValidSequenceCheck(bracketStringArray[i]))
                {
                    Console.WriteLine(bracketStringArray[i] + failMessage);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(bracketStringArray[i] + successMessage);
                    Console.WriteLine();
                }
            }
        }
    }
}
