using Lithomancer.Core.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lithomancer.Core.Entities
{
	[TestClass]
	public class EquipmentTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			Equipment equipment = new Equipment(new EquipmentProperties());

			Assert.IsNotNull(equipment.Stats);
			Assert.IsNotNull((equipment as IEquipment).Stats);
		}
	}
}
