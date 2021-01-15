using System;

namespace Lithomancer.Core
{
	public interface IModifiable
	{
		IComponent<T> GetComponent<T>(Enum key);
		IComponent<T> GetBaseComponent<T>(Enum key);
	}
}
