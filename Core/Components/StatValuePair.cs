using System;

namespace Lithomancer.Core.Components
{
	public struct StatValuePair
	{
		public Enum Stat { get; }
		public int Value { get; }

		public StatValuePair(Enum stat, int value)
		{
			Stat = stat;
			Value = value;
		}
	}
}
