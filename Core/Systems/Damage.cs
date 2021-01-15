using System;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Systems
{
	[Serializable]
	public struct Damage
	{
		public Element Element { get; }
		public int Value { get; }

		public Damage(Element element, int value)
		{
			Element = element;
			Value = value;
		}
	}
}
