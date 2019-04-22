using System;

namespace BracketPositionValidator
{
    class Program
    {
        public static void Main(string[] args)
        {   
            string successMessage = " - brackets are correct";
            string failMessage = " - brackets are not correct";

            BracketCheckByExample exampleCheck = new BracketCheckByExample();
            exampleCheck.doBracketCheck(successMessage , failMessage);

            Console.WriteLine("Input a string of round or square bracers to check if all the bracers are closed");
            string inputString = Console.ReadLine();

            BracketValidSequenceChecker bracketChecker = new BracketValidSequenceChecker();

            if (!bracketChecker.BracketIsValidSequenceCheck(inputString))
            {
                throw new ArgumentOutOfRangeException(inputString + failMessage);
            }

            Console.WriteLine(inputString + successMessage);
            Console.ReadKey();
        }
    }
}