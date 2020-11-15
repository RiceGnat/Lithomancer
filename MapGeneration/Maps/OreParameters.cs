using System;

namespace Lithomancer.MapGeneration.Maps
{
	[Serializable]
	public struct OreParameters
	{
		public double Density { get; set; }
		public double Rate { get; set; }
		public int Layers { get; set; }
	}
}
