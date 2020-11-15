using System;

namespace Lithomancer.Core.Components
{
	internal class ComponentDecorator : IComponent
	{
		private readonly IComponent source;

		public ComponentDecorator(IComponent source) => this.source = source;

		public Enum Key => source.Key;
		public IEntity Owner => source.Owner;
	}
}
