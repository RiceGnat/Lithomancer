using System;
using System.Collections.Generic;
using System.Linq;
using Lithomancer.MapGeneration.Maps;

namespace Lithomancer.Core.Systems
{
	[Serializable]
	public class WorldTemplate : IWorldGenerator
	{
		public int Tileset { get; set; }
		public int FloorCount { get; set; } = 100;
		public WorldFloorParameters Parameters { get; set; }
		public IList<WorldOreParameters> Ores { get; } = new List<WorldOreParameters>();

		public IWorld GenerateInstance(int seed)
		{
			Random random = new Random(seed);

			IWorldFloor[] floors = new IWorldFloor[FloorCount];

			for (int i = 0; i < FloorCount; i++)
			{
				IEnumerable<WorldOreParameters> ores = Ores.Where(o => i >= o.MinimumFloor && i <= o.MaximumFloor);
				IMineMap map;
				do {
					map = new MineMap(random.Next(), Parameters.Terrain, Parameters.Mine, ores.Select(o => o.DistributionParameters));
				} while (map.MainRegion.Area < Parameters.MinimumArea || map.Doors.Count < Parameters.Mine.DoorCount);
				floors[i] = new WorldFloorInstance(Tileset, map, ores.Select(o => o.Id));
			}

			return new WorldInstance(seed, Tileset, floors);
		}
	}
}
