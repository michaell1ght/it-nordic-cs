using System;
using System.Collections.Generic;
using System.Text;

namespace Player
{
	abstract class FlyingAgregate : IFlyingObject
	{
		public int MaxHeight { get; private set; }
		public int CurrentHeight { get; private set; }

		public FlyingAgregate(int maxHeight)
		{
			MaxHeight = maxHeight;
			CurrentHeight = 0;
		}

		public void TakeUpper(int delta)
		{
			if (delta <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			if (CurrentHeight + delta > MaxHeight)
			{
				CurrentHeight = MaxHeight;
			}

			else
			{
				CurrentHeight += delta;
			}
		}

		public void TakeLower(int delta)
		{
			if (delta <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			if (CurrentHeight - delta > 0)
			{
				CurrentHeight -= delta;
			}

			if (CurrentHeight - delta == 0)
			{
				CurrentHeight = 0;
			}
			if (CurrentHeight - delta < 0)
			{
				throw new InvalidOperationException("Crash");
			}
		}

		public virtual void WriteAllProperties2()
		{
			Console.WriteLine($"CurrentHeight= {CurrentHeight}");
			Console.WriteLine($"MaxHeight= {MaxHeight}");
		}
	}
}
