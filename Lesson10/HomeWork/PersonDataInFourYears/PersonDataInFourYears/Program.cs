using System;

namespace PersonDataInFourYears
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person();
            Person person3 = new Person();
            Person[] personArray = 
                {
                person1,
                person2,
                person3
                };

            for (int i =0; i<personArray.Length;i++)
            {
                Console.WriteLine($"Enter name {i + 1}:");
                personArray[i].Name = Console.ReadLine();
                if (!InputDataValidator.IsLetter(personArray[i].Name))
                {   
                    throw new ArgumentOutOfRangeException();
                }
                    Console.WriteLine($"Enter age {i + 1}:");
                    personArray[i].Age = Int32.Parse(Console.ReadLine());
                    if (!InputDataValidator.IsCorrectAge(personArray[i].Age) == true)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            foreach (Person person in personArray)
            {
                Console.WriteLine(person.NameAndAgeInForYears);
            }
            Console.ReadKey();
        }
    }
}
