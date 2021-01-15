using System.Collections.Generic;

namespace Lithomancer.MapGeneration.Maps
{
	public interface IMineMap : ICaveTerrain
	{
		IReadOnlyList<Segment> Doors { get; }
		IReadOnlyList<IHeightMap> Ores { get; }

		bool IsDoor(int x, int y);
	}
}
