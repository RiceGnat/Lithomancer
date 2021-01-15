using Lithomancer.Core.Components;
using Lithomancer.Core.Entities;

namespace Lithomancer.Core.Systems
{
	public interface IDamageCalculator
	{
		Damage CalculateOutgoingDamage(IUnit unit, int skillMod, Element element, int finalMod);
	}
}