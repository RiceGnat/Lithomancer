using System.Collections.Generic;

namespace Lithomancer.MapGeneration.Maps
{
	public class BlobExtractor
	{
		private readonly List<Pixel> queue = new List<Pixel>();
		private readonly HashSet<(int, int)> labeled = new HashSet<(int, int)>();
		private readonly List<Blob> blobs = new List<Blob>();
		private readonly int label = 0;
		private readonly bool[,] map;

		public BlobExtractor(bool[,] map)
		{
			this.map = map;

			for (int i = 0; i < map.GetLength(0); i++)
			{
				for (int j = 0; j < map.GetLength(1); j++)
				{
					if (TryPushQueue(i, j))
					{
						List<Pixel> blob = new List<Pixel>();
						HashSet<Pixel> edge = new HashSet<Pixel>();
						HashSet<Pixel> border = new HashSet<Pixel>();

						while (queue.Count > 0)
						{
							Pixel p = PopQueue();

							foreach ((int x, int y) in new[] { (p.X + 1, p.Y), (p.X, p.Y + 1), (p.X - 1, p.Y), (p.X, p.Y - 1) })
							{
								TryPushQueue(x, y);
								if (map.CheckBounds(x, y) && map[x, y])
								{
									edge.Add(p);
									border.Add(new Pixel(x, y, label));
								}
							}

							blob.Add(p);
						}

						blobs.Add(new Blob(label, blob.Count, blob, edge.Count, edge, border.Count, border));
						label++;
					}
				}
			}

			Blobs = blobs.AsReadOnly();
			blobs.Sort((a, b) => b.Area.CompareTo(a.Area));
		}

		public IEnumerable<Blob> Blobs { get; }

		private bool TryPushQueue(int x, int y)
		{
			bool valid = map.CheckBounds(x, y) && !map[x, y] && !labeled.Contains((x, y));

			if (valid)
			{
				Pixel p = new Pixel(x, y, label);
				queue.Add(p);
				labeled.Add((x, y));
			}

			return valid;
		}

		private Pixel PopQueue()
		{
			Pixel p = queue[0];
			queue.RemoveAt(0);
			return p;
		}
	}
}
