using System.Collections.Generic;

namespace Lithomancer.MapGeneration.Maps
{
	public interface ICaveTerrain : IHeightMap
	{
		Blob MainRegion { get; }
		IEnumerable<Blob> Regions { get; }
	}
}