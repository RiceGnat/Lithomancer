using Lithomancer.Core.Components;
using Lithomancer.Core.Entities;

namespace Lithomancer.Core.Systems
{
	public class DamageCalculator : IDamageCalculator
	{
		private int CalculateOutgoingDamage(int atk, int skill, int elemental, int final) =>
			// using floats so we don't accidentally hit int max
			(int)(atk * skill / 100f * (1 + elemental / 100f) * (1 + final / 100f));

		public Damage CalculateOutgoingDamage(IUnit unit, int skillMod, Element element, int finalMod) =>
			new Damage(element, CalculateOutgoingDamage(unit.Stats[UnitStat.ATK], skillMod, unit.Stats[element], finalMod));
	}
}
