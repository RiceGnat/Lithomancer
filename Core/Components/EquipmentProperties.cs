using System;

namespace Lithomancer.Core.Components
{
	[Serializable]
	public struct EquipmentProperties : IItemProperties
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public EquipmentType Type { get; set; }
		ItemType IItemProperties.Type => ItemType.Equipment;
	}
}
