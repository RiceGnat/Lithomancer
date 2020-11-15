using System;
using System.Collections.Generic;

namespace Lithomancer.Core
{
	[Serializable]
	public abstract class Entity : IEntity
	{
		private readonly Dictionary<Enum, IComponent> components = new Dictionary<Enum, IComponent>();

		public string Name { get; set; }
		public string Description { get; set; }

		protected void AddComponent(IComponent component) => components[component.Key] = component;

		public virtual T GetComponent<T>(Enum key) where T : class => components[key] as T;
	}
}
