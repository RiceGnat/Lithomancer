using System;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class Gemstone : Item<GemProperties>, IGemstone
	{
		public Gemstone(GemProperties properties) : base(properties)
		{
			AddComponent<IStats>(ItemComponent.Stats, this, Stats);
		}

		public Element Element => Properties.Element;

		IStats IGemstone.Stats => GetComponent<IStats>(ItemComponent.Stats).Object;
		public IEditableStats Stats { get; } = new StatsMap();
	}
}
