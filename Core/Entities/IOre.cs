using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	public interface IOre : IItem<OreProperties>
	{
		OreCategory Category { get; }
		Element Element { get; }
		IStats Stats { get; }
	}
}
