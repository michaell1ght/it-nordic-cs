using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
	public class Pet
	{
		public string Name;
		public string Kind;
		public char Sex;
		public byte Age;

		public string Description
	{
		get
		{
			return $"{Name} is a {Kind} ({Sex}) of {Age} years old";
		}
	}
	}
}
