using System;
using System.Collections.Generic;
using System.Text;

namespace Player
{
	interface IFlyingObject
	{
		int MaxHeight { get; }
		int CurrentHeight { get; }

		void TakeUpper(int delta);
		void TakeLower(int delta);
	}
}
