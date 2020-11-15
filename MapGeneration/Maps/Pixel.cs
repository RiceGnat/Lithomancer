using System;

namespace Lithomancer.MapGeneration.Maps
{
	[Serializable]
	public struct Pixel
	{
		public Pixel(int x, int y, int label)
		{
			X = x;
			Y = y;
			Label = label;
		}

		public int X { get; }
		public int Y { get; }
		public int Label { get; }

		public override bool Equals(object obj) => 
			obj is Pixel pixel &&
			X == pixel.X &&
			Y == pixel.Y &&
			Label == pixel.Label;

		public override int GetHashCode()
		{
			int hashCode = -1385726360;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			hashCode = hashCode * -1521134295 + Label.GetHashCode();
			return hashCode;
		}

		public static implicit operator (int X, int Y)(Pixel p) => (p.X, p.Y);
	}
}
