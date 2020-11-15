using System;

namespace Lithomancer.Core.Components
{
	public interface IStats
	{
		int this[Enum stat] { get; }
	}
}
