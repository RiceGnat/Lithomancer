using System;

namespace Lithomancer.Core.Components
{
	[Serializable]
	public class VolatileStats : StatsMap, IVolatileStats
	{
		public void Initialize(IStats source, params Enum[] stats)
		{
			foreach(Enum stat in stats)
			{
				this[stat] = source[stat];
			}
		}
	}
}
