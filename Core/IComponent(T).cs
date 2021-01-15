namespace Lithomancer.Core
{
	public interface IComponent<T> : IComponent
	{
		T Object { get; }
	}
}
