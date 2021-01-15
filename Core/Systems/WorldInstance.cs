using System;
using System.Collections.Generic;

namespace Lithomancer.Core.Systems
{
	[Serializable]
	internal class WorldInstance : IWorld
	{
		public WorldInstance(int seed, int tileset, IEnumerable<IWorldFloor> floors)
		{
			Seed = seed;
			Tileset = tileset;
			Floors = new List<IWorldFloor>(floors).AsReadOnly();
		}

		public int Seed { get; }
		public int Tileset { get; }
		public IReadOnlyList<IWorldFloor> Floors { get; }
	}
}
