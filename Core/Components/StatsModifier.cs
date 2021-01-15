using System;

namespace Lithomancer.Core.Components
{
	[Serializable]
	internal class StatsModifier : IStats
	{
		private class Aggregator : IStats
		{
			private readonly IStats source;
			private readonly StatsModifier modifier;

			public Aggregator(IStats source, StatsModifier modifier)
			{
				this.source = source;
				this.modifier = modifier;
			}

			public int this[Enum stat] => source[stat] + modifier.modifications[stat];
		}

		private IStats modifications;

		public StatsModifier(IStats stats) => modifications = stats;

		public int this[Enum stat] => modifications[stat];

		public IStats GetModifiedStats(IStats source) => modifications != null ? new Aggregator(source, this) : source;
	}
}
