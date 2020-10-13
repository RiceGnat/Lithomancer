using System.Collections.Generic;

namespace Lithomancer.MapGeneration.Maps
{
	public interface IMine : ICaveTerrain
	{
		IEnumerable<Segment> Doors { get; }
		int DoorCount { get; }
	}
}
