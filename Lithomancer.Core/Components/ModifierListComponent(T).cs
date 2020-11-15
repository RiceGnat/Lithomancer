using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lithomancer.Core.Components
{
	[Serializable]
	public class ModifierListComponent<T> : Component, IList<T>, IModifier where T : class, IModifier
	{
		private readonly ModifierList list = new ModifierList();

		public ModifierListComponent(Enum key, IEntity owner) : base(key, owner) { }

		public T this[int index]
		{
			get => list[index] as T;
			set => list[index] = value;
		}

		int ICollection<T>.Count => list.Count;
		bool ICollection<T>.IsReadOnly => ((ICollection<T>)list).IsReadOnly;

		void ICollection<T>.Add(T item) => list.Add(item);
		void ICollection<T>.Clear() => list.Clear();
		bool ICollection<T>.Contains(T item) => list.Contains(item);
		void ICollection<T>.CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
		IEnumerator<T> IEnumerable<T>.GetEnumerator() => list.Select(m => m as T).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
		int IList<T>.IndexOf(T item) => list.IndexOf(item);
		void IList<T>.Insert(int index, T item) => list.Insert(index, item);
		bool ICollection<T>.Remove(T item) => list.Remove(item);
		void IList<T>.RemoveAt(int index) => list.RemoveAt(index);

		public IModifiable GetModified(IModifiable source) => list.GetModified(source);
	}
}
