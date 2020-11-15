using System;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class UnitModifier : Modifier
	{
		private readonly StatsModifier stats = new StatsModifier();

		public IEditableStats Stats => stats;

		protected override T GetModifiedComponent<T>(Enum key, IModifiable source)
		{
			switch (key)
			{
				case UnitComponents.Stats: return stats.GetModifiedStats(source.GetComponent<IStats>(key)) as T;
				default: return source.GetComponent<T>(key);
			}
		}
	}
}
