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
			Stats stats = new Stats
			{
				[TestStats.A] = 1
			};

			Assert.AreEqual(1, stats[TestStats.A]);
		}

		[TestMethod]
		public void DefaultValueTest()
		{
			Stats stats = new Stats(1);

			Assert.AreEqual(1, stats[TestStats.A]);
		}
	}
}
