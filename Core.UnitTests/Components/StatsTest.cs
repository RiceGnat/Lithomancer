using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lithomancer.Core.Components
{
	[TestClass]
	public class StatsTest
	{
		[TestMethod]
		public void GetSetTest()
		{
			StatsMap stats = new StatsMap
			{
				[TestStats.A] = 1
			};

			Assert.AreEqual(1, stats[TestStats.A]);
		}

		[TestMethod]
		public void DefaultValueTest()
		{
			StatsMap stats = new StatsMap(1);

			Assert.AreEqual(1, stats[TestStats.A]);
		}
	}
}
