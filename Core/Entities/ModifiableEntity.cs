using System;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class ModifiableEntity : Entity, IModifiable
	{
		private readonly ModifierList modifiers = new ModifierList();

		public void AddModifier(IModifier modifier) => modifiers.Add(modifier);

		IComponent<T> IModifiable.GetBaseComponent<T>(Enum key) => base.GetComponent<T>(key);
		IComponent<T> IModifiable.GetComponent<T>(Enum key) => base.GetComponent<T>(key);

		public override IComponent<T> GetComponent<T>(Enum key) => modifiers.GetModified(this).GetComponent<T>(key);
	}
}
