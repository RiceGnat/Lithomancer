namespace Lithomancer.MapGeneration.Maps
{
	public struct CaveProperties
	{
		public (int X, int Y) Size { get; set; }
		public double WallDensity { get; set; }
		public bool FillHoles { get; set; }
	}
}
