namespace Lithomancer.MapGeneration.Graphs
{
	public class CartesianNode<T> : ICartesianNode<T>
	{
		private readonly ICartesianNode<T>[] connections = new ICartesianNode<T>[4];

		public CartesianNode(T obj, params ICartesianNode<T>[] connections)
		{
			if (connections != null)
			{
				for (int i = 0; i < this.connections.Length; i++)
				{
					this.connections[i] = connections[i];
				}
			}

			Object = obj;
		}

		public T Object { get; }

		public ICartesianNode<T> GetConnection(int direction) => connections[direction];
		public ICartesianNode<T> GetConnection(CartesianDirections direction) => GetConnection((int)direction);
	}
}
