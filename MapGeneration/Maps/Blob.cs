using System;
using System.Collections.Generic;
using System.Linq;

namespace Lithomancer.MapGeneration.Maps
{
	public class Blob
	{
		public Blob(int label, int area, IEnumerable<Pixel> pixels, int edgeLength, IEnumerable<Pixel> edge, int borderLength, IEnumerable<Pixel> border)
		{
			Label = label;
			Area = area;
			Pixels = pixels?.ToList().AsReadOnly() ?? throw new ArgumentNullException(nameof(pixels));
			EdgeLength = edgeLength;
			Edge = edge?.ToList().AsReadOnly() ?? throw new ArgumentNullException(nameof(edge));
			BorderLength = borderLength;
			Border = border?.ToList().AsReadOnly() ?? throw new ArgumentNullException(nameof(border));
		}

		public int Label { get; }
		public int Area { get; }
		public IEnumerable<Pixel> Pixels { get; }
		public int EdgeLength { get; }
		public IEnumerable<Pixel> Edge { get; }
		public int BorderLength { get; }
		public IEnumerable<Pixel> Border{ get; }
	}
}
