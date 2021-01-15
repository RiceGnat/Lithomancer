using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	public interface IEquipment : IItem<EquipmentProperties>, IModifier
	{
		new EquipmentType Type { get; }
		IStats Stats { get; }
	}
}
