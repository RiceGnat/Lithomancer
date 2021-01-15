using System;
using System.Collections;
using System.Collections.Generic;
using Lithomancer.Core.Components;

namespace Lithomancer.Core.Entities
{
	[Serializable]
	public class SocketableEquipment : Equipment
	{
		[Serializable]
		private class SocketList : IList<IGemstone>, IStats
		{
			private readonly List<IGemstone> gemstones = new List<IGemstone>();
			private readonly List<StatsModifier> modifiers = new List<StatsModifier>();
			private readonly IStats source;
			private IStats result;

			public SocketList(IStats source)
			{
				this.source = source;
				RefreshResult();
			}

			int IStats.this[Enum stat] => result[stat];

			public IGemstone this[int index]
			{
				get => gemstones[index];
				set
				{
					gemstones[index] = value;
					modifiers[index] = GetModifier(value);
					RefreshResult();
				}
			}

			public int Count => gemstones.Count;

			public bool IsReadOnly => false;

			private StatsModifier GetModifier(IGemstone gem) => gem != null ? new StatsModifier(gem.Stats) : null;

			public void RefreshResult()
			{
				result = source;
				foreach (StatsModifier modifier in modifiers)
				{
					if (modifier != null) result = modifier.GetModifiedStats(result);
				}
			}

			public void Add() => Add(null);

			public void Add(IGemstone item)
			{
				gemstones.Add(item);
				modifiers.Add(GetModifier(item));
				RefreshResult();
			}

			public void Clear()
			{
				gemstones.Clear();
				modifiers.Clear();
				RefreshResult();
			}

			public void Insert(int index, IGemstone item)
			{
				gemstones.Insert(index, item);
				modifiers.Insert(index, GetModifier(item));
				RefreshResult();
			}

			public void RemoveAt(int index)
			{
				gemstones.RemoveAt(index);
				modifiers.RemoveAt(index);
				RefreshResult();
			}

			public bool Remove(IGemstone item)
			{
				int index = IndexOf(item);
				if (index > 0)
				{
					RemoveAt(index);
					return true;
				}
				return false;
			}

			public int IndexOf(IGemstone item) => gemstones.IndexOf(item);

			public bool Contains(IGemstone item) => gemstones.Contains(item);

			public void CopyTo(IGemstone[] array, int arrayIndex) => gemstones.CopyTo(array, arrayIndex);

			public IEnumerator<IGemstone> GetEnumerator() => gemstones.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		private SocketList sockets;

		public SocketableEquipment(EquipmentProperties properties) : base(properties)
		{
			AddComponent<IList<IGemstone>>(EquipmentComponent.Sockets, this, sockets);
		}

		public IList<IGemstone> Sockets => sockets;

		protected override IStats GetModifierStats() => sockets = new SocketList(base.GetModifierStats());

		public void AddSockets(int count)
		{
			for (int i = 0; i < count; i++)
			{
				sockets.Add();
			}
		}
	}
}
