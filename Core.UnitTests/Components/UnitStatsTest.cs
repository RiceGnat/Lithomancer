using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lithomancer.Core.Components
{
	[TestClass]
	public class UnitStatsTest
	{
		[DataTestMethod]
		[DataRow(10, 5, 20)]
		[DataRow(10, 5, 0)]
		[DataRow(0, 5, 10)]
		[DataRow(1, 0, 0)]
		public void CalculateTest(int baseStat, int percent, int flat)
		{
			Mock<IStats> mockStats = new Mock<IStats>();
			mockStats.SetupGet(m => m[UnitStat.ATK]).Returns(flat);
			mockStats.SetupGet(m => m[UnitStat.ATKPercent]).Returns(percent);

			UnitStatsResolver stats = new UnitStatsResolver(() => mockStats.Object);

			Assert.AreEqual(flat * (100 + percent) / 100, stats[UnitStat.ATK]);
		}
	}
}
