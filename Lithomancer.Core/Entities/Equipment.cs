using System;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class Equipment : Entity, IEquipment
	{
		private readonly UnitModifier modifier = new UnitModifier();

		IStats IEquipment.Stats => Stats;

		public EquipmentTypes Type { get; set; }
		public IEditableStats Stats => modifier.Stats;

		IModifiable IModifier.GetModified(IModifiable source) => modifier.GetModified(source);
	}
}
