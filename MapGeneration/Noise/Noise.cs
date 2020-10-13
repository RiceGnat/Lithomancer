using System;

namespace Lithomancer.MapGeneration.Noise
{
	public abstract class Noise : INoise
	{
		private readonly int[] values;

		protected Noise(int[] values, int length, int max)
		{
			this.values = new int[length];
			Array.Copy(values, this.values, length);
			Length = length;
			Max = max;
		}

		public int this[int index] => values[index];

		public int Length { get; }
		public int Max { get; }
	}
}
