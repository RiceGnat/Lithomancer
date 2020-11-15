using System;

namespace Lithomancer.MapGeneration.Maps
{
	[Serializable]
	public class HeightMap : IHeightMap
	{
		private readonly int[,] values;

		public HeightMap(int max, int[,] values)
		{
			this.values = values.Clone() as int[,];
			MaxHeight = max;
			Size = this.values.GetSize();
		}

		public int this[int x, int y] => values[x, y];

		public (int X, int Y) Size { get; }
		public int MaxHeight { get; }
	}
}
