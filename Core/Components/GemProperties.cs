using System;

namespace Lithomancer.Core.Components
{
	[Serializable]
	public struct GemProperties : IItemProperties
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		ItemType IItemProperties.Type => ItemType.Gemstone;
		public Element Element { get; set; }
	}
}
