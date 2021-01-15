using System;

namespace Lithomancer.Core
{
	[Serializable]
	public abstract class Component : IComponent
	{
		internal Component(Enum key, IEntity owner)
		{
			Key = key;
			Owner = owner;
		}

		public Enum Key { get; }
		public IEntity Owner { get; }
	}
}
