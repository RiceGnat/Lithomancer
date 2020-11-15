using System;

namespace Lithomancer.MapGeneration.Maps
{
	[Serializable]
	public struct CaveProperties
	{
		public (int X, int Y) Size { get; set; }
		public double WallDensity { get; set; }
		public bool FillHoles { get; set; }
	}
}
