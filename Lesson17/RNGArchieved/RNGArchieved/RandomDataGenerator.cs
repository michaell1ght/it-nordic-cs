using System;
using System.Collections.Generic;
using System.Text;

namespace RNGArchieved
{
	public delegate void RandomDataGeneratedHandler(int bytesDone, int totalBytes);

	public event RandomDataGeneratedHandler RandomDataGenerated;

	public event EventHandler RandomDataGenerationDone;


	class RandomDataGenerator
	{
		public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
		{
			byte[] randomDataArray = new byte[dataSize];
			Random rng = new Random();
			for (int i = 0; i <= byte.MaxValue; i++)
			{
				randomDataArray[i]= (byte)rng.Next(255);
				if (i + 1 % bytesDoneToRaiseEvent == 0)
				{
					OnRandomDataGenerated(i + 1, dataSize);
				}
			}
			//Call event + final event
			OnRandomDataGenerationDone(s);

			return randomDataArray;
		}
		protected virtual void OnRandomDataGenerated(object sender s, EventArgs e)
		{
		
		}

		protected virtual void OnRandomDataGenerationDone(object sender s, EventArgs e)
		{
		
		}
	}
}
