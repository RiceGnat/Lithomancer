using System;

namespace Lithomancer.Core
{
	public interface IEntity
	{
		string Name { get; }
		string Description { get; }

		IComponent<T> GetComponent<T>(Enum key);
	}
}
