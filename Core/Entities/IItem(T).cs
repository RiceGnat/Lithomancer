using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	public interface IItem<T> : IItem where T : IItemProperties
	{
		T Properties { get; }
	}
}
