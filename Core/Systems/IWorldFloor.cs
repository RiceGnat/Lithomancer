using System.Collections.Generic;
using Lithomancer.MapGeneration.Maps;

namespace Lithomancer.Core.Systems
{
	public interface IWorldFloor
	{
		int Tileset { get; }
		IMineMap Map { get; }
		IReadOnlyList<int> Ores { get; }
	}
}
