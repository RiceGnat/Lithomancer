using System;
using System.Collections.Generic;

namespace Lithomancer.Core.Components
{
	[Serializable]
	public class StatsComponent : Component, IEditableStats
	{
		private readonly Stats stats = new Stats();

		public StatsComponent(Enum key, IEntity owner) : base(key, owner) { }

		public int this[Enum stat]
		{
			get => stats[stat];
			set => stats[stat] = value;
		}
	}
}
