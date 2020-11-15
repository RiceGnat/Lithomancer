using System.Collections.Generic;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	public interface IUnit : IEntity, IModifiable
	{
		IStats Stats { get; }
		IEnumerable<IEquipment> Equipment { get; }
	}
}
