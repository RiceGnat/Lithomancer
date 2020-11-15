using System;

namespace Lithomancer.Core
{
	public interface IEntity
	{
		string Name { get; }
		string Description { get; }

		T GetComponent<T>(Enum key) where T : class;
	}
}
