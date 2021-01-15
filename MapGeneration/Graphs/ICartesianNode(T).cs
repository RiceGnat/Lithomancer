namespace Lithomancer.MapGeneration.Graphs
{
	public interface ICartesianNode<T>
	{
		T Object { get; }
		ICartesianNode<T> GetConnection(int direction);
		ICartesianNode<T> GetConnection(CartesianDirections direction);
	}
}
