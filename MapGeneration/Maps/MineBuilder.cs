using System;
using System.Collections.Generic;

namespace Lithomancer.MapGeneration.Maps
{
	public class MineBuilder
	{
		private readonly Random random;
		private CaveProperties caveProperties;
		private MineProperties mineProperties;
		private int minimumArea;
		private readonly List<OreParameters> oreParameters = new List<OreParameters>();

		public MineBuilder(int seed)
		{
			random = new Random(seed);
			caveProperties = new CaveProperties();
			mineProperties = new MineProperties();
		}

		private MineBuilder This(Action func)
		{
			func();
			return this;
		}

		public MineBuilder Size(int x, int y) => This(() => caveProperties.Size = (x, y));

		public MineBuilder WallDensity(double density) => This(() => caveProperties.WallDensity = density);

		public MineBuilder FillHoles() => This(() => caveProperties.FillHoles = true);

		public MineBuilder MinimumMainArea(int area) => This(() => minimumArea = area);

		public MineBuilder RockDensity(double density) => This(() => mineProperties.RockDensity = density);

		public MineBuilder SelectDoors(int count, int size, int minDistance) => This(() =>
		{
			mineProperties.DoorCount = count;
			mineProperties.DoorSize = size;
			mineProperties.DoorDistance = minDistance;
		});

		public MineBuilder EntraceRadius(int radius) => This(() => mineProperties.ClearEntranceRadius = radius);

		public MineBuilder AddOre(double density, double rate, int layers) => This(() => oreParameters.Add(new OreParameters
		{
			Density = density,
			Rate = rate,
			Layers = layers
		}));

		private bool IsValid(Mine output) =>
			output.MainRegion.Area >= minimumArea ||
			output.Doors.Count == mineProperties.DoorCount;

		public Mine Generate(int seed) => new Mine(seed, caveProperties, mineProperties, oreParameters);

		public Mine Generate()
		{
			Mine output;

			do
			{
				output = Generate(random.Next());
			} while (!IsValid(output));

			return output;
		}
	}
}
