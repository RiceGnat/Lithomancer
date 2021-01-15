using System.Collections.Generic;

namespace Lithomancer.MapGeneration.Maps
{
	public interface ICaveTerrain : IHeightMap
	{
		int Seed { get; }
		Blob MainRegion { get; }
		IEnumerable<Blob> Regions { get; }
	}
}