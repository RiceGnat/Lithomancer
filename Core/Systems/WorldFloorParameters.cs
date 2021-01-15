using System;
using Lithomancer.MapGeneration.Maps;

namespace Lithomancer.Core.Systems
{
	[Serializable]
	public struct WorldFloorParameters
	{
		public CaveParameters Terrain { get; set; }
		public MineParameters Mine { get; set; }
		public int MinimumArea { get; set; }
	}
}
