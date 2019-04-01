using System;
using System.Collections.Generic;

namespace BracketPositionValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            int openedRoundBracerCount = 0;
            int openedSquareBracerCount = 0;
            int i = 0;
            string errorMessage = "incorrect bracket at char ";
            Stack<char> bracerStack = new Stack<char>();

            Console.WriteLine("Input a string of round or square bracers to check if all the bracers are closed");
            string intpuString = Console.ReadLine();

            if (String.IsNullOrEmpty(intpuString))
            {
                throw new ArgumentNullException();
            }
            for (i = 0; i < intpuString.ToCharArray().Length; i++)
            {
                if (!BracketValidator.isRoundOrSquareBracket(intpuString.ToCharArray()[i]))
                {
                    throw new ArgumentOutOfRangeException();
                }

                bracerStack.Push(intpuString.ToCharArray()[i]);

                if (BracketTypeChecker.isOpenedBracket(bracerStack.Peek()) == (int)BracketType.roundBracer)
                {
                    if (openedRoundBracerCount > 0)
                    {
                        throw new ArgumentOutOfRangeException(errorMessage + (i + 1));
                    }
                    openedRoundBracerCount++;
                }

                if (BracketTypeChecker.isOpenedBracket(bracerStack.Peek()) == (int)BracketType.squareBracer)
                {
                    if (openedSquareBracerCount > 0)
                    {
                        throw new ArgumentOutOfRangeException(errorMessage + (i + 1));
                    }
                    openedSquareBracerCount++;
                }

                if (BracketTypeChecker.isClosedBracket(bracerStack.Peek()) == (int)BracketType.roundBracer)
                {
                    if(openedRoundBracerCount <= 0)
                    {
                        throw new ArgumentOutOfRangeException(errorMessage + (i + 1));
                    }
                    openedRoundBracerCount--;
                }


                if (BracketTypeChecker.isClosedBracket(bracerStack.Peek()) == (int)BracketType.squareBracer)
                {
                    if (openedSquareBracerCount <= 0)
                    {
                        throw new ArgumentOutOfRangeException(errorMessage + (i + 1));
                    }
                    openedSquareBracerCount--;
                }
            }

            if (openedRoundBracerCount == 0 && openedSquareBracerCount == 0)
            {
                Console.WriteLine("Brackets are correct");
                Console.ReadKey();
            }
            else
            {
                throw new ArgumentOutOfRangeException(errorMessage + (i + 1));
            }
        }
    }
}