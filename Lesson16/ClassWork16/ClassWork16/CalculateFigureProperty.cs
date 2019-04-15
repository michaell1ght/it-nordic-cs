using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork16
{
	class CalculateFigureProperty
	{
		public double Radius { get; }


		public CalculateFigureProperty(double radius)
		{
			Radius = radius;
		}
		public double Calculate(Func<double, double> func)
		{
			return func(Radius);
		}
	}
}
