using System;
using System.Collections.Generic;

namespace Lithomancer.Core
{
	[Serializable]
	public abstract class EntityBase
	{
		private readonly Dictionary<Enum, IComponent> components = new Dictionary<Enum, IComponent>();

		internal EntityBase() { }

		protected void AddComponent<T>(Enum key, IEntity owner, T componentObject) => components[key] = new Component<T>(key, owner, componentObject);

		public virtual IComponent<T> GetComponent<T>(Enum key) => (IComponent<T>)components[key];
	}
}
