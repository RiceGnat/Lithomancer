using System;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class Item<T> : EntityBase, IItem<T>, IEntity where T : IItemProperties
	{
		public Item(T properties)
		{
			AddComponent(ItemComponent.Properties, this, properties);
		}

		public T Properties => GetComponent<T>(ItemComponent.Properties).Object;

		public int Id => Properties.Id;
		public ItemType Type => Properties.Type;
		public string Name => Properties.Name;
		public string Description => Properties.Description;
	}
}
