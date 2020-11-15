using System;
using System.Collections.Generic;

namespace Lithomancer.Core.Components
{
	[Serializable]
	public class Stats : IEditableStats
	{
		private readonly Dictionary<Enum, int> stats = new Dictionary<Enum, int>();
		private readonly int defaultValue;

		public Stats() : this(0) { }

		public Stats(int defaultValue) => this.defaultValue = defaultValue;

		public int this[Enum stat]
		{
			get => stats.ContainsKey(stat) ? stats[stat] : defaultValue;
			set => stats[stat] = value;
		}
	}
}
