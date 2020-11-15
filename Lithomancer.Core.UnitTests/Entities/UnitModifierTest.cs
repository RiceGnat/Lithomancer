using System;
using Lithomancer.Core.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lithomancer.Core.Entities
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
			mockModifiable.Setup(m => m.GetComponent<IStats>(UnitComponents.Stats)).Returns(mockStats.Object);
			mockModifiable.Setup(m => m.GetComponent<IComponent>(UnitComponents.Equipment)).Returns(new Mock<IComponent>().Object);
			modifiable = mockModifiable.Object;

			modifier = new UnitModifier();
			modifier.Stats[TestStats.A] = 1;
		}

		[TestMethod]
		public void GetModifiedStatsTest()
		{
			IModifiable modified = modifier.GetModified(modifiable);

			Assert.AreEqual(2, modified.GetComponent<IStats>(UnitComponents.Stats)[TestStats.A]);
			Assert.AreEqual(1, modified.GetComponent<IStats>(UnitComponents.Stats)[TestStats.B]);
		}

		[TestMethod]
		public void GetModifiedDefaultTest()
		{
			IModifiable modified = modifier.GetModified(modifiable);

			Assert.AreEqual(modifiable.GetComponent<IComponent>(UnitComponents.Equipment), modified.GetComponent<IComponent>(UnitComponents.Equipment));
		}
	}
}
