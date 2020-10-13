namespace Lithomancer.MapGeneration.Noise
{
	public interface INoise
	{
		int this[int index] { get; }

		int Length { get; }
		int Max { get; }
	}
}
