using System;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            string[] userNameArray = new string[3];
            int[] userAgeArray = new int[3];
            int i;
            for (i = 0; i < userNameArray.Length; i++)
            {
                Console.WriteLine($"Write name of the person {i + 1}");
                userNameArray[i]=Console.ReadLine();
                foreach (char c in userNameArray[i])
                {
                    if (Char.IsLetter(c))
                    {
                        Console.WriteLine(new FormatException("The value of parameter name must not contain number"));
                        Console.ReadKey();
                        Environment.Exit(13);
                    }
                }
            Console.WriteLine($"Write age of the person {userNameArray[i]}");
                if (int.TryParse(Console.ReadLine(), out int usernameParseResult))
                {
                    userAgeArray[i] = usernameParseResult;
                }
                else
                {
                    Console.WriteLine(new FormatException("The value of parameter age must be integer"));
                    Console.ReadKey();
                    Environment.Exit(13);
                }
            }
            Console.WriteLine(Environment.NewLine);
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine($"Name: {userNameArray[i]}, age in 4 years: {userAgeArray[i] + 4}");
            }
            Console.ReadKey();
        }
    }
}