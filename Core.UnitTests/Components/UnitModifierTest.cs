using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lithomancer.Core.Components
{
	[TestClass]
	public class UnitModifierTest
	{
		private UnitModifier modifier;
		private IModifiable modifiable;

		[TestInitialize]
		public void Setup()
		{
			Mock<IStats> mockStats = new Mock<IStats>();
			mockStats.SetupGet(m => m[It.IsAny<TestStats>()]).Returns(1);

			Mock<IModifiable> mockModifiable = new Mock<IModifiable>();
			mockModifiable.Setup(m => m.GetComponent<IStats>(UnitComponent.Stats)).Returns(MockComponent.Create(mockStats));
			mockModifiable.Setup(m => m.GetComponent<IComponent>(UnitComponent.Equipment)).Returns(MockComponent.Create(new Mock<IComponent>()));
			modifiable = mockModifiable.Object;

			modifier = new UnitModifier(new StatsMap
			{
				[TestStats.A] = 1
			});
		}

		[TestMethod]
		public void GetModifiedStatsTest()
		{
			IModifiable modified = modifier.GetModified(modifiable);

			Assert.AreEqual(2, modified.GetComponent<IStats>(UnitComponent.Stats).Object[TestStats.A]);
			Assert.AreEqual(1, modified.GetComponent<IStats>(UnitComponent.Stats).Object[TestStats.B]);
		}

		[TestMethod]
		public void GetModifiedDefaultTest()
		{
			IModifiable modified = modifier.GetModified(modifiable);

			Assert.AreEqual(modifiable.GetComponent<IComponent>(UnitComponent.Equipment), modified.GetComponent<IComponent>(UnitComponent.Equipment));
		}
	}
}
