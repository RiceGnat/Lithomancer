using System;

namespace Lithomancer.Core.Components
{
	public interface IVolatileStats : IEditableStats
	{
		void Initialize(IStats source, params Enum[] stats);
	}
}
