using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Lithomancer.MapGeneration.Maps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lithomancer.Core.Systems
{
	[TestClass]
	public class WorldTemplateTest
	{
		private WorldTemplate template;

		[TestInitialize]
		public void Setup()
		{
			template = new WorldTemplate
			{
				FloorCount = 3,
				Parameters = new WorldFloorParameters
				{
					Terrain = new CaveParameters
					{
						Size = (32, 32),
						WallDensity = 0.5,
						FillHoles = false
					},
					Mine = new MineParameters
					{
						RockDensity = 0.5,
						DoorCount = 2,
						DoorSize = 1,
						DoorDistance = 5,
						ClearEntranceRadius = 1
					}
				},
				Ores =
				{
					new WorldOreParameters
					{
						Id = 0,
						MinimumFloor = 0,
						MaximumFloor = 2
					},
					new WorldOreParameters
					{
						Id = 1,
						MinimumFloor = 1,
						MaximumFloor = 2
					}
				}
			};
		}

		[TestMethod]
		public void InstanceParametersTest()
		{
			IWorld world = template.GenerateInstance(1);

			Assert.AreEqual(3, world.Floors.Count);
			Assert.AreEqual(1, world.Floors[0].Ores.Count);
			Assert.AreEqual(2, world.Floors[1].Ores.Count);
			Assert.AreEqual(2, world.Floors[2].Ores.Count);

			foreach (IWorldFloor floor in world.Floors)
			{
				Assert.AreEqual(2, floor.Map.Doors.Count);
			}
		}

		[DataTestMethod]
		[DataRow(1)]
		[DataRow(2)]
		[DataRow(3)]
		public void DeterministicGenerationTest(int seed)
		{
			IWorld world1 = template.GenerateInstance(seed);
			IWorld world2 = template.GenerateInstance(seed);

			for (int i = 0; i < template.FloorCount; i++)
			{
				for (int x = 0; x < template.Parameters.Terrain.Size.X; x++)
				{
					for (int y = 0; y < template.Parameters.Terrain.Size.Y; y++)
					{
						Assert.AreEqual(world1.Floors[i].Map[x, y], world2.Floors[i].Map[x, y]);
					}
				}
			}
		}

		[TestMethod]
		public void SerializationTest()
		{
			IWorld world = template.GenerateInstance(1);

			using (MemoryStream ms = new MemoryStream())
			{
				new BinaryFormatter().Serialize(ms, world);
			}
		}
	}
}
