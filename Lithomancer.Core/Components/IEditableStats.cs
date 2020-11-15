using System;

namespace Lithomancer.Core.Components
{
	public interface IEditableStats : IStats
	{
		new int this[Enum stat] { get; set; }
	}
}
