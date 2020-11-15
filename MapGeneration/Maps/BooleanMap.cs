using System;

namespace Lithomancer.MapGeneration.Maps
{
	[Serializable]
	public class BooleanMap : IHeightMap
	{
		private readonly bool[,] values;

		public BooleanMap(bool[,] values)
		{
			this.values = values.Clone() as bool[,];
			Size = this.values.GetSize();
		}

		public bool this[int x, int y] => values[x, y];
		int IHeightMap.this[int x, int y] => values[x, y] ? 1 : 0;

		public (int X, int Y) Size { get; }
		public int MaxHeight => 1;
	}
}
