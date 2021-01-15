using System;

namespace Lithomancer.Core
{
	[Serializable]
	public abstract class Modifier : IModifier
	{
		private class Decorator : IModifiable
		{
			private readonly IModifiable source;
			private readonly Modifier modifier;

			public Decorator(IModifiable source, Modifier modifier)
			{
				this.source = source;
				this.modifier = modifier;
			}

			IComponent<T> IModifiable.GetBaseComponent<T>(Enum key) => source.GetBaseComponent<T>(key);
			IComponent<T> IModifiable.GetComponent<T>(Enum key) => modifier.GetModifiedComponent<T>(key, source);
		}

		protected abstract IComponent<T> GetModifiedComponent<T>(Enum key, IModifiable source);

		public IModifiable GetModified(IModifiable source) => new Decorator(source, this);
	}
}
