using System;

namespace Lithomancer.Core
{
	[Serializable]
	public class Component<T> : Component, IComponent<T>
	{
		public Component(Enum key, IEntity owner, T componentObject) : base(key, owner)
		{
			Object = componentObject;
		}

		public T Object { get; }

		public IComponent<TOut> As<TOut>() where TOut : class => new Component<TOut>(Key, Owner, Object as TOut);
	}
}
