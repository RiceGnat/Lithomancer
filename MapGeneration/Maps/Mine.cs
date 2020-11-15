using System;
using System.Collections.Generic;
using System.Linq;
using Lithomancer.MapGeneration.CellularAutomata;

namespace Lithomancer.MapGeneration.Maps
{
	[Serializable]
	public class Mine : IMine
	{
		private readonly CaveTerrain cave;
		private readonly List<IHeightMap> ores = new List<IHeightMap>();

		public Mine(int seed, CaveProperties caveProperties, MineProperties mineProperties, IEnumerable<OreParameters> ores)
		{
			Random random = new Random(seed);
			Seed = seed;

			int x = caveProperties.Size.X;
			int y = caveProperties.Size.Y;

			cave = new CaveTerrain(random.Next(), caveProperties);

			Doors = SelectDoors(random.Next(), mineProperties.DoorCount, mineProperties.DoorSize, mineProperties.DoorDistance, MainRegion.Border);

			IHeightMap rocks = GenerateRocks(random.Next(), x, y, mineProperties.RockDensity);
			int height = rocks.MaxHeight + 1;
			Terrain = new HeightMap(height, ValueArray.Create(x, y, (i, j) => {
				if (cave[i, j] > 0) return height;
				else if (Doors.Count > 0 && Doors[0].Center.DistanceTo((i, j)) <= mineProperties.ClearEntranceRadius) return 0;
				else return rocks[i, j];
			}));

			foreach (OreParameters p in ores)
			{
				this.ores.Add(GenerateOre(random.Next(), x, y, p.Density, p.Rate, p.Layers, Terrain));
			}

			Ores = this.ores.AsReadOnly();
		}

		public int Seed { get; }
		public (int X, int Y) Size => cave.Size;
		public IHeightMap Terrain { get; }
		public Blob MainRegion => cave.MainRegion;
		public IEnumerable<Blob> Regions => cave.Regions;
		public IReadOnlyList<Segment> Doors { get; }
		public IReadOnlyList<IHeightMap> Ores { get; }

		int IHeightMap.this[int x, int y] => Terrain[x, y];
		int IHeightMap.MaxHeight => Terrain.MaxHeight;

		private static IReadOnlyList<Segment> SelectDoors(int seed, int count, int size, int distance, IEnumerable<Pixel> border)
		{
			Random random = new Random(seed);
			HashSet<Pixel> pixels = new HashSet<Pixel>(border);
			List<Segment> candidates = new List<Segment>();

			foreach (Pixel p in pixels)
			{
				List<Pixel> h = new List<Pixel> { p };
				List<Pixel> v = new List<Pixel> { p };

				for (int i = 1; i < size; i++)
				{
					int offset = (i + 1) / 2 * (1 - i % 2 * 2);

					if (h != null)
					{
						Pixel ph = new Pixel(p.X + offset, p.Y, p.Label);
						if (pixels.Contains(ph))
						{
							h.Add(ph);
						}
						else h = null;
					}

					if (v != null)
					{
						Pixel pv = new Pixel(p.X, p.Y + offset, p.Label);
						if (pixels.Contains(pv))
						{
							v.Add(pv);
						}
						else v = null;
					}
				}

				if (h != null) candidates.Add(new Segment(h[0], h));
				if (v != null) candidates.Add(new Segment(v[0], v));
			}

			List<Segment> output = new List<Segment>();
			int tries = 0;

			while (tries < candidates.Count && output.Count < count)
			{
				Segment selected = candidates[random.Next(0, candidates.Count)];

				if (output.TrueForAll(n => n.Center.DistanceTo(selected.Center) > distance))
				{
					output.Add(selected);
				}

				candidates.Remove(selected);
				tries++;
			}

			return output.AsReadOnly();
		}

		private static IHeightMap GenerateRocks(int seed, int x, int y, double density)
		{
			CellularAutomaton ca = new CellularAutomaton(seed, new RuleSet(density.Lerp(0.1, 0.3), false, (region, generation) => region.GetCount() > 2));

			IHeightMap layer1 = new BooleanMap(ca.Generate(x, y, 4));
			IHeightMap layer2 = new BooleanMap(ca.Generate(x, y, 2));

			return new HeightMap(2, ValueArray.Create(x, y, (i, j) => layer1[i, j] + layer2[i, j]));
		}

		private static IHeightMap GenerateOre(int seed, int x, int y, double density, double rate, int layers, IHeightMap terrain)
		{
			Random random = new Random(seed);

			RuleSet ruleSet = new RuleSet(density.Lerp(0.1, 0.3), false, (region, generation) => region.GetCount() > 2);
			CellularAutomaton ca = new CellularAutomaton(random.Next(), ruleSet);
			IHeightMap[] maps = new IHeightMap[layers];

			for (int l = 0; l < layers; l++)
			{
				BooleanMap map = new BooleanMap(ca.Generate(x, y, 4));
				BooleanMap noise = new BooleanMap(ValueArray.Create(x, y, (i, j) => random.NextDouble() <= rate));

				maps[l] = new BooleanMap(ValueArray.Create(x, y, (i, j) => (terrain[i, j] == 1 || terrain[i, j] == 2) && map[i, j] && noise[i, j]));
			}

			return new HeightMap(layers, ValueArray.Create(x, y, (i, j) => maps.Select(m => m[i, j]).Sum()));
		}
	}
}
