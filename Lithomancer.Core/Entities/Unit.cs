using System;
using System.Collections.Generic;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class Unit : ModifiableEntity, IUnit
	{
		public Unit()
		{
			AddComponent(new StatsComponent(UnitComponents.Stats, this));

			ModifierListComponent<IEquipment> equipment = new ModifierListComponent<IEquipment>(UnitComponents.Equipment, this);

			AddComponent(equipment);
			AddModifier(equipment);
		}

		IEnumerable<IEquipment> IUnit.Equipment => Equipment;

		public IStats Stats => GetComponent<IStats>(UnitComponents.Stats);
		public IEditableStats BaseStats => (this as IModifiable).GetBaseComponent<IEditableStats>(UnitComponents.Stats);
		public IList<IEquipment> Equipment => GetComponent<IList<IEquipment>>(UnitComponents.Equipment);
	}
}
