using System;

namespace BracketPositionValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string errorMessage = "incorrect brackets";

            Console.WriteLine("Input a string of round or square bracers to check if all the bracers are closed");
            string inputString = Console.ReadLine();

            if (String.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException();
            }
            BracketValidSequenceChecker bracketChecker = new BracketValidSequenceChecker(inputString.ToCharArray());
            if(!bracketChecker.BracketIsValidSequenceCheck())
            {
                throw new ArgumentOutOfRangeException(errorMessage);
            }
            Console.WriteLine("Brackets are correct");
            Console.ReadKey();
        }
    }
}