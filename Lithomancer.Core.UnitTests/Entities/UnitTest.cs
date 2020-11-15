using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lithomancer.Core.Entities
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			Unit unit = new Unit();

			Assert.IsNotNull(unit.Stats);
			Assert.IsInstanceOfType(unit.Stats, typeof(IComponent));
			Assert.IsNotNull(unit.Equipment);
			Assert.IsInstanceOfType(unit.Equipment, typeof(IComponent));
		}

		[TestMethod]
		public void EquipmentCollectionTest()
		{
			IEquipment equipment = new Equipment
			{
				Stats = { [TestStats.A] = 1 }
			};

			Unit unit = new Unit
			{
				BaseStats = { [TestStats.A] = 1 },
				Equipment = { equipment, equipment }
			};

			Assert.AreEqual(3, unit.Stats[TestStats.A]);
		}
	}
}
