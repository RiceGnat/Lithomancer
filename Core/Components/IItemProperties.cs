namespace Lithomancer.Core.Components
{
	public interface IItemProperties
	{
		int Id { get; }
		ItemType Type { get; }
		string Name { get; }
		string Description { get; }
	}
}
