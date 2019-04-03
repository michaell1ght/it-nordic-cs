using System;
using System.Collections.Generic;
using System.Text;

namespace Player
{
	class Plane : FlyingAgregate, IFlyingObject, IPropertiesWriter
	{

		public byte EngineCount { get; private set; }

		public Plane(int maxHeight, byte engineCount) : base(maxHeight)
		{
			EngineCount = engineCount;
			Console.WriteLine("It's a plane, welcome aboard");
		}

		public void WriteAllProperties()
			{
				Console.WriteLine($"EngineCount = {EngineCount},CurrentHeight= {CurrentHeight},MaxHeight= {MaxHeight}");
			}

		public override void WriteAllProperties2()
		{
			base.WriteAllProperties2();
			Console.WriteLine($"EngineCount = {EngineCount}");
		}

	}
}
