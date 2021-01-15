using Lithomancer.Core.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lithomancer.Core.Entities
{
	[TestClass]
	public class SocketableEquipmentTest
	{
		[TestMethod]
		public void StatsTest()
		{
			SocketableEquipment equipment = new SocketableEquipment(new EquipmentProperties())
			{
				Stats =
				{
					[TestStats.A] = 10,
					[TestStats.B] = 10
				}
			};

			Assert.AreEqual(10, (equipment as IEquipment).Stats[TestStats.A]);
			Assert.AreEqual(10, (equipment as IEquipment).Stats[TestStats.B]);

			Mock<IGemstone> mockGem = new Mock<IGemstone>();
			Mock<IStats> mockStats = new Mock<IStats>();
			mockStats.SetupGet(m => m[TestStats.A]).Returns(1);
			mockGem.SetupGet(m => m.Stats).Returns(mockStats.Object);

			equipment.Sockets.Add(mockGem.Object);

			Assert.AreEqual(11, (equipment as IEquipment).Stats[TestStats.A]);
			Assert.AreEqual(10, (equipment as IEquipment).Stats[TestStats.B]);
		}
	}
}
