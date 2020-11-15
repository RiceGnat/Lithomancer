using System;
using System.Collections.Generic;

namespace Lithomancer.Core.Components
{
	[Serializable]
	public class StatsModifier : IEditableStats
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

		private readonly Stats modifications = new Stats();

		public int this[Enum stat]
		{
			get => modifications[stat];
			set => modifications[stat] = value;
		}

		public IStats GetModifiedStats(IStats source) => new Aggregator(source, this);
	}
}
