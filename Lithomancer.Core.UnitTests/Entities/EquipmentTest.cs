using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lithomancer.Core.Entities
{
	[TestClass]
	public class EquipmentTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			Equipment equipment = new Equipment();

			Assert.IsNotNull(equipment.Stats);
		}
	}
}
