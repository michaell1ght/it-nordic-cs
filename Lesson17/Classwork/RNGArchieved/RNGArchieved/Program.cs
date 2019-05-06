using System;

namespace RNGArchieved
{
	class Program
	{
		static void Main(string[] args)
		{
			RandomDataGenerator randomDataGenerator = new RandomDataGenerator();
            randomDataGenerator.RandomDataGeneratig += RandomDataGenerator_RandomDataGeneratig;
            randomDataGenerator.RandomDataGenerationDone += RandomDataGenerator_RandomDataGenerationDone;
            randomDataGenerator.GetRandomData(107, 10);
			// положить результат GetRandomData в файл.
		}

        private static void RandomDataGenerator_RandomDataGeneratig(int bytesDone, int totalBytes)
        {
            Console.WriteLine($"work in progress {bytesDone} parts of {totalBytes} done ");
        }

        private static void RandomDataGenerator_RandomDataGenerationDone(object sender, EventArgs e)
        {
            Console.WriteLine("work is done");
        }
    }
}

