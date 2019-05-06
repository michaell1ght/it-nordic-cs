using System;
using System.Collections.Generic;
using System.Text;

namespace RNGArchieved
{
	class RandomDataGenerator
	{
        public delegate void RandomDataGeneratedHandler(int bytesDone, int totalBytes);

        public event RandomDataGeneratedHandler RandomDataGeneratig;

        public event EventHandler RandomDataGenerationDone;

        public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
		{
            var counter = bytesDoneToRaiseEvent;
            byte[] randomDataArray = new byte[dataSize];
			Random rng = new Random();

			for (int i = 0; i < dataSize; i++)
			{
				randomDataArray[i]= (byte)rng.Next(255);
				if ((i + 1) % counter == 0)
				{
                    OnRandomDataGeneratig(counter, dataSize);
                    counter += bytesDoneToRaiseEvent;
                }
			}

            counter = dataSize;
            OnRandomDataGeneratig(counter, dataSize);
            OnRandomDataGenerationDone(this, EventArgs.Empty);
			return randomDataArray;
		}
		protected virtual void OnRandomDataGeneratig(int bytesDone, int totalBytes)
		{
            RandomDataGeneratig?.Invoke(bytesDone, totalBytes);
        }

        protected virtual void OnRandomDataGenerationDone(object sender, EventArgs e)
		{
            RandomDataGenerationDone?.Invoke(sender,e);
        }
    }
}
