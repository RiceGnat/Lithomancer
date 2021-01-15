using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	public interface IItem : IEntity
	{
		ItemType Type { get; }
	}
}
