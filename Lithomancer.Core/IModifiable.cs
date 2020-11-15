using System;

namespace Lithomancer.Core
{
	public interface IModifiable
	{
		T GetComponent<T>(Enum key) where T : class;
		T GetBaseComponent<T>(Enum key) where T : class;
	}
}
