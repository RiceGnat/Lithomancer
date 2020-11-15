using System.Collections.Generic;

namespace Lithomancer.MapGeneration.Maps
{
	public interface IMine : ICaveTerrain
	{
		IReadOnlyList<Segment> Doors { get; }
	}
}
