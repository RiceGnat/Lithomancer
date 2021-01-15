using System;
using System.Collections.Generic;
using System.Linq;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class Unit : ModifiableEntity, IUnit
	{
		public Unit()
		{
			AddComponent<IStats>(UnitComponent.Stats, this, BaseStats);
			Stats = new UnitStatsResolver(() => GetComponent<IStats>(UnitComponent.Stats).Object);

			ModifierList<IEquipment> equipment = new ModifierList<IEquipment>();
			AddComponent<IList<IEquipment>>(UnitComponent.Equipment, this, equipment);
			AddModifier(equipment);

			AddComponent<IUnitState>(UnitComponent.State, this, new UnitState());
		}

		IEnumerable<IEquipment> IUnit.Equipment => Equipment;

		public IStats Stats { get; }
		public IEditableStats BaseStats { get; } = new StatsMap();
		public IList<IEquipment> Equipment => GetComponent<IList<IEquipment>>(UnitComponent.Equipment).Object;

		public IEnumerable<StatValuePair> EnumerateStats() =>
			new Enum[] { UnitStat.ATK, UnitStat.DEF, UnitStat.HP }
				.Concat(Enum.GetValues(typeof(Element)).Cast<Enum>().Where(e => !e.Equals(Element.None)))
				.Select(stat => new StatValuePair(stat, Stats[stat]));
	}
}
