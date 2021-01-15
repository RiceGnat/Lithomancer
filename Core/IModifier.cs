namespace Lithomancer.Core
{
	public interface IModifier
	{
		IModifiable GetModified(IModifiable source);
	}
}
