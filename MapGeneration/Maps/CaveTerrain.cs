using System;
using System.Collections.Generic;
using System.Linq;
using Lithomancer.MapGeneration.CellularAutomata;
using Lithomancer.MapGeneration.Noise;

namespace Lithomancer.MapGeneration.Maps
{
	[Serializable]
	public class CaveTerrain : ICaveTerrain
	{
		private readonly IHeightMap map;

		public CaveTerrain(int seed, CaveParameters parameters)
		{
			Random random = new Random(seed);
			Seed = seed;

			int x = parameters.Size.X;
			int y = parameters.Size.Y;

			bool[,] bounds = GenerateBounds(random.Next(), x, y, 5, -1);
			bool[,] walls = GenerateWalls(random.Next(), x, y, parameters.WallDensity);
			bool[,] map = ValueArray.Create(x, y, (i, j) => bounds[i, j] || walls[i, j]);

			Regions = GetAreas(map);
			MainRegion = Regions.First();

			if (parameters.FillHoles)
			{
				map = FillHoles(map, Regions.Skip(1));
				Regions = Regions.Take(1).ToList().AsReadOnly();
			}

			this.map = new BooleanMap(map);
		}

		public int this[int x, int y] => map[x, y];

		public int Seed { get; }
		public (int X, int Y) Size => map.Size;
		public int MaxHeight => map.MaxHeight;
		public Blob MainRegion { get; }
		public IEnumerable<Blob> Regions { get; }

		private static bool[,] GenerateBounds(int seed, int x, int y, int width, double power)
		{
			Random random = new Random(seed);
			bool[,] output = new bool[x, y];

			INoise top = new SineNoise(random.Next(), x, width, f => Math.Pow(f, power));
			INoise right = new SineNoise(random.Next(), y, width, f => Math.Pow(f, power));
			INoise bottom = new SineNoise(random.Next(), x, width, f => Math.Pow(f, power));
			INoise left = new SineNoise(random.Next(), y, width, f => Math.Pow(f, power));

			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j <= top[i]; j++)
				{
					output[i, Math.Min(j, y)] |= true;
				}

				for (int j = 0; j <= bottom[i]; j++)
				{
					output[i, Math.Max(y - j - 1, 0)] |= true;
				}
			}

			for (int i = 0; i < y; i++)
			{
				for (int j = 0; j <= left[i]; j++)
				{
					output[Math.Min(j, x), i] |= true;
				}

				for (int j = 0; j <= right[i]; j++)
				{
					output[Math.Max(x - j - 1, 0), i] |= true;
				}
			}

			return output;
		}

		private static bool[,] GenerateWalls(int seed, int x, int y, double density)
		{
			CellularAutomaton ca = new CellularAutomaton(seed, new RuleSet(density.Lerp(0.35, 0.5), true, (region, generation) => region.GetCount() > 4));

			return ca.Generate(x, y, 11);
		}

		private static IEnumerable<Blob> GetAreas(bool[,] map)
		{
			BlobExtractor extractor = new BlobExtractor(map);
			return extractor.Blobs;
		}

		private static bool[,] FillHoles(bool[,] map, IEnumerable<Blob> holes)
		{
			bool[,] output = map.Clone() as bool[,];

			foreach (Blob b in holes)
			{
				foreach (Pixel p in b.Pixels)
				{
					output[p.X, p.Y] = true;
				}
			}

			return output;
		}
	}
}
