using Lithomancer.Core.Components;
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

			Assert.IsNotNull(unit.BaseStats);
			Assert.IsNotNull(unit.Stats);
			Assert.IsNotNull(unit.GetComponent<IStats>(UnitComponent.Stats));
			Assert.IsNotNull(unit.Equipment);
		}

		[TestMethod]
		public void EquipmentCollectionTest()
		{
			IEquipment equipment = new Equipment(new EquipmentProperties())
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
