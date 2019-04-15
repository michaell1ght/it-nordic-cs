using System;
using Calculator.Figure;

namespace Calculator.Operation
{
	public static class DoOperation
	{
		public static double getPerimeter(double radius)
		{
			return 2 * Math.PI * radius;
		}
		public static double getSquare(double radius)
		{
			return Math.PI * Math.Pow(radius, 2);
		}
	}
}
