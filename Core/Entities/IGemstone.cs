using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	public interface IGemstone : IItem<GemProperties>
	{
		Element Element { get; }
		IStats Stats { get; }
	}
}
