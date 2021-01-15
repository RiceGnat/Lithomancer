using System.Collections.Generic;

namespace Lithomancer.Core.Systems
{
	public interface IWorld
	{
		int Seed { get; }
		int Tileset { get; }
		IReadOnlyList<IWorldFloor> Floors { get; }
	}
}
