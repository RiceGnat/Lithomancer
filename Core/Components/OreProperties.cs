using System;

namespace Lithomancer.Core.Components
{
	[Serializable]
	public struct OreProperties : IItemProperties
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public OreCategory Category { get; set; }
		ItemType IItemProperties.Type => ItemType.Ore;
		public Element Element { get; set; }
	}
}
