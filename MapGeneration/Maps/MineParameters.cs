using System;

namespace Lithomancer.MapGeneration.Maps
{
	[Serializable]
	public struct MineParameters
	{
		public double RockDensity { get; set; }
		public int DoorCount { get; set; }
		public int DoorSize { get; set; }
		public int DoorDistance { get; set; }
		public int ClearEntranceRadius { get; set; }
	}
}
