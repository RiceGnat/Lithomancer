using System;

namespace Lithomancer.Core
{
	public interface IComponent
	{
		Enum Key { get; }
		IEntity Owner { get; }
	}
}
