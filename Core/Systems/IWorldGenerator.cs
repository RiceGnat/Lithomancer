namespace Lithomancer.Core.Systems
{
	public interface IWorldGenerator
	{
		IWorld GenerateInstance(int seed);
	}
}
