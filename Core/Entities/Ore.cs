using System;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class Ore : Item<OreProperties>, IOre
	{
		public Ore(OreProperties properties) : base(properties)
		{
			AddComponent<IStats>(ItemComponent.Stats, this, Stats);
		}

		public OreCategory Category => Properties.Category;
		public Element Element => Properties.Element;

		IStats IOre.Stats => GetComponent<IStats>(ItemComponent.Stats).Object;

		public IEditableStats Stats { get; } = new StatsMap();
	}
}
