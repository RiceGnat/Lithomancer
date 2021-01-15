using System;
using System.Collections.Generic;
using Lithomancer.MapGeneration.Maps;

namespace Lithomancer.Core.Systems
{
	[Serializable]
	internal class WorldFloorInstance : IWorldFloor
	{
		public WorldFloorInstance(int tileset, IMineMap map, IEnumerable<int> ores)
		{
			Tileset = tileset;
			Map = map;
			Ores = new List<int>(ores).AsReadOnly();
		}

		public int Tileset { get; }
		public IMineMap Map { get; }
		public IReadOnlyList<int> Ores { get; }
	}
}
