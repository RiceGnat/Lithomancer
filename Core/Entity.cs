using System;

namespace Lithomancer.Core
{
	[Serializable]
	public abstract class Entity : EntityBase, IEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
