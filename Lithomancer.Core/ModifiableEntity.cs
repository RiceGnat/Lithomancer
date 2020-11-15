using System;

namespace Lithomancer.Core
{
	[Serializable]
	public class ModifiableEntity : Entity, IModifiable
	{
		private readonly ModifierList modifiers = new ModifierList();

		public void AddModifier(IModifier modifier) => modifiers.Add(modifier);

		T IModifiable.GetBaseComponent<T>(Enum key) => base.GetComponent<T>(key);
		T IModifiable.GetComponent<T>(Enum key) => base.GetComponent<T>(key);

		public override T GetComponent<T>(Enum key) => modifiers.GetModified(this).GetComponent<T>(key);
	}
}
