using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lithomancer.Core.Components
{
	[TestClass]
	public class StatsModifierTest
	{
		[TestMethod]
		public void GetModifiedStatsTest()
		{
			StatsModifier statsModifier = new StatsModifier(new StatsMap
			{
				[TestStats.A] = 1
			});

			Mock<IStats> mockStats = new Mock<IStats>();
			mockStats.SetupGet(m => m[It.IsAny<TestStats>()]).Returns(1);

			Assert.AreEqual(2, statsModifier.GetModifiedStats(mockStats.Object)[TestStats.A]);
			Assert.AreEqual(1, statsModifier.GetModifiedStats(mockStats.Object)[TestStats.B]);
		}
	}
}
