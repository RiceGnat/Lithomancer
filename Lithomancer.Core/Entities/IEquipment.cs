using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	public interface IEquipment : IEntity, IModifier
	{
		EquipmentTypes Type { get; }
		IStats Stats { get; }
	}
}
