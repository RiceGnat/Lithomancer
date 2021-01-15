using System;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class Equipment : Item<EquipmentProperties>, IEquipment
	{
		private readonly IStats stats;
		private readonly UnitModifier modifier;

		public Equipment(EquipmentProperties properties) : base(properties)
		{
			stats = GetModifierStats();
			AddComponent(ItemComponent.Stats, this, stats);
			modifier = new UnitModifier(stats);
		}

		EquipmentType IEquipment.Type => Properties.Type;

		IStats IEquipment.Stats => stats;

		public IEditableStats Stats { get; } = new StatsMap();

		IModifiable IModifier.GetModified(IModifiable source) => modifier.GetModified(source);

		protected virtual IStats GetModifierStats() => Stats;
	}
}
