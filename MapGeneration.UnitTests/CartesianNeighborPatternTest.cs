using System;
using Lithomancer.MapGeneration.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lithomancer.MapGeneration.UnitTests
{
	[TestClass]
	public class CartesianNeighborPatternTest
	{
		[DataTestMethod]
		[DataRow(0, 0, 0)]
		[DataRow(255, 255, UInt16.MaxValue)]
		[DataRow(7, 7, 0)]
		[DataRow(143, 143, 8321)]
		public void ConnectsWithTest(int pattern1, int pattern2, int matchResult)
		{
			Assert.AreEqual(matchResult, new CartesianNeighborPattern(pattern1).ConnectsWith(new CartesianNeighborPattern(pattern2)));
		}

		[DataTestMethod]
		[DataRow(0, 0, true)]
		[DataRow(255, 255, true)]
		[DataRow(7, 34, false)]
		[DataRow(143, 143, true)]
		public void EqualsTest(int pattern1, int pattern2, bool matchResult)
		{
			Assert.AreEqual(matchResult, new CartesianNeighborPattern(pattern1) == new CartesianNeighborPattern(pattern2));
		}

		[DataTestMethod]
		[DataRow(0, 0, 15)]
		[DataRow(255, 255, 15)]
		[DataRow(7, 112, 4)]
		[DataRow(119, 119, 5)]
		[DataRow(19, 76, 8)]
		[DataRow(19, 70, 0)]
		public void IsRotationTest(int pattern1, int pattern2, int matchResult)
		{
			Assert.AreEqual(matchResult, new CartesianNeighborPattern(pattern1).IsRotation(new CartesianNeighborPattern(pattern2)));
		}
	}
}
