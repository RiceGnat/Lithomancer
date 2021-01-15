using System;
using System.Collections.Generic;

namespace Lithomancer.MapGeneration.Maps
{
	public class MineBuilder
	{
		private readonly Random random;
		private CaveParameters caveParameters;
		private MineParameters mineParameters;
		private int minimumArea;
		private readonly List<OreParameters> oreParameters = new List<OreParameters>();

		public MineBuilder(int seed)
		{
			random = new Random(seed);
			caveParameters = new CaveParameters();
			mineParameters = new MineParameters();
		}

		private MineBuilder This(Action func)
		{
			func();
			return this;
		}

		public MineBuilder Size(int x, int y) => This(() => caveParameters.Size = (x, y));

		public MineBuilder WallDensity(double density) => This(() => caveParameters.WallDensity = density);

		public MineBuilder FillHoles() => This(() => caveParameters.FillHoles = true);

		public MineBuilder MinimumMainArea(int area) => This(() => minimumArea = area);

		public MineBuilder RockDensity(double density) => This(() => mineParameters.RockDensity = density);

		public MineBuilder SelectDoors(int count, int size, int minDistance) => This(() =>
		{
			mineParameters.DoorCount = count;
			mineParameters.DoorSize = size;
			mineParameters.DoorDistance = minDistance;
		});

		public MineBuilder EntraceRadius(int radius) => This(() => mineParameters.ClearEntranceRadius = radius);

		public MineBuilder AddOre(double density, double rate, int layers) => This(() => oreParameters.Add(new OreParameters
		{
			Density = density,
			Rate = rate,
			Layers = layers
		}));

		private bool IsValid(MineMap output) => output.MainRegion.Area >= minimumArea && output.Doors.Count == mineParameters.DoorCount;

		public MineMap Generate(int seed) => new MineMap(seed, caveParameters, mineParameters, oreParameters);

		public MineMap Generate()
		{
			MineMap output;

			do
			{
				output = Generate(random.Next());
				System.Diagnostics.Debug.WriteLine(output.MainRegion.Area);
				System.Diagnostics.Debug.WriteLine(minimumArea);
			} while (!IsValid(output));

			return output;
		}
	}
}
