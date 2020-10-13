namespace Lithomancer.MapGeneration.Maps
{
	public interface IHeightMap
	{
		int this[int x, int y] { get; }

		(int X, int Y) Size { get; }
		int MaxHeight { get; }
	}
}
