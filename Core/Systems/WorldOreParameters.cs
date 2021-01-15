using System;
using Lithomancer.MapGeneration.Maps;

namespace Lithomancer.Core.Systems
{
	[Serializable]
	public struct WorldOreParameters
	{
		public int Id { get; set; }
		public OreParameters DistributionParameters { get; set; }
		public int MinimumFloor { get; set; }
		public int MaximumFloor { get; set; }
	}
}
