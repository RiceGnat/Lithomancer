using System;
using System.Collections.Generic;
using System.Linq;

namespace Lithomancer.MapGeneration.Maps
{
	public class Segment
	{
		public Segment(int x, int y, IEnumerable<Pixel> pixels) : this((x, y), pixels) { }

		public Segment((int x, int y) center, IEnumerable<Pixel> pixels)
		{
			Center = center;
			Pixels = pixels?.ToList().AsReadOnly() ?? throw new ArgumentNullException(nameof(pixels));
		}

		public (int X, int Y) Center { get; }
		public IEnumerable<Pixel> Pixels { get; }
	}
}
