using System;

namespace Lithomancer.Core.Components
{
	[Serializable]
	public class UnitState : IUnitState
	{
		public IVolatileStats VolatileStats { get; } = new VolatileStats();
	}
}
