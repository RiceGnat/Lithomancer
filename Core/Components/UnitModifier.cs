using System;

namespace Lithomancer.Core.Components
{
	[Serializable]
	internal class UnitModifier : Modifier
	{
		private readonly StatsModifier stats;

		public UnitModifier(IStats stats)
		{
			this.stats = new StatsModifier(stats);
		}

		protected override IComponent<T> GetModifiedComponent<T>(Enum key, IModifiable source)
		{
			switch (key)
			{
				case UnitComponent.Stats:
					IComponent<IStats> component = source.GetComponent<IStats>(key);
					return new Component<T>(component.Key, component.Owner, (T)stats.GetModifiedStats(component.Object));
				default: return source.GetComponent<T>(key);
			}
		}
	}
}
