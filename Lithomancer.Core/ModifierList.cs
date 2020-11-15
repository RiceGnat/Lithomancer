using System;
using System.Collections.Generic;
using System.Linq;

namespace Lithomancer.Core
{
	[Serializable]
	public class ModifierList : List<IModifier>, IModifier
	{
		public IModifiable GetModified(IModifiable source) => this.Aggregate(source, (stack, modifier) => modifier.GetModified(stack));
	}
}
