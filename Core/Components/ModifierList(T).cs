using System;
using System.Collections.Generic;
using System.Linq;

namespace Lithomancer.Core.Components
{
	[Serializable]
	internal class ModifierList<T> : List<T>, IModifier where T : class, IModifier
	{
		public IModifiable GetModified(IModifiable source) => this.Aggregate(source, (stack, modifier) => modifier.GetModified(stack));
	}
}
