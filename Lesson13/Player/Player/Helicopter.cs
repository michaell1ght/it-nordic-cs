using System;
using System.Collections.Generic;
using System.Text;

namespace Player
{
	class Helicopter : FlyingAgregate, IFlyingObject, IPropertiesWriter
	{
		public byte BladesCount { get; private set; }

		public Helicopter(int maxHeight,byte bladesCount) : base(maxHeight)
		{
			BladesCount = bladesCount;
			Console.WriteLine("It's a helicopter< welcome aboard");
		}

		public void WriteAllProperties()
			{
				Console.WriteLine($"BladesCount = {BladesCount},CurrentHeight= {CurrentHeight},MaxHeight= {MaxHeight}");
			}

		public override void WriteAllProperties2()
		{
			base.WriteAllProperties2();
			Console.WriteLine($"BladesCount = {BladesCount}");
		}
	}
}
