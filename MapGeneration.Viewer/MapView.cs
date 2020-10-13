using System;
using System.Drawing;
using System.Windows.Forms;
using Lithomancer.MapGeneration.Maps;

namespace Lithomancer.MapGeneration.Viewer
{
	public partial class MapView : Form
	{
		private const int MAP_SIZE = 64;
		private const int TILE_SIZE = 5;
		private const int BITMAP_SIZE = MAP_SIZE * TILE_SIZE;
		private const int CONTROL_SPACE = 32;

		Random random = new Random();
		MineBuilder factory;
		Mine map;

		public MapView()
		{
			InitializeComponent();

			Size = new Size(BITMAP_SIZE + CONTROL_SPACE + 16, BITMAP_SIZE + CONTROL_SPACE + 39);
			pictureBox1.Size = new Size(BITMAP_SIZE, BITMAP_SIZE);
			pictureBox1.Location = new Point(CONTROL_SPACE, 0);

			wallDensity.Value = 5;
			rockDensity.Value = 5;

			NewFactory();

			pictureBox1.Click += (sender, e) =>
			{
				GenerateCave();
			};

			factorySeed.TextChanged += (sender, e) =>
			{
				if (Int32.TryParse(factorySeed.Text, out int seed))
				{
					NewFactory(seed);
				}
			};

			mapSeed.TextChanged += (sender, e) =>
			{
				if (Int32.TryParse(mapSeed.Text, out int seed))
				{
					GenerateCave(seed);
				}
			};

			wallDensity.ValueChanged += (sender, e) => RefreshCave();
			rockDensity.ValueChanged += (sender, e) => RefreshCave();
			showEdges.CheckedChanged += (sender, e) => UpdateBitmap();
		}

		private void NewFactory()
		{
			int seed = random.Next();
			factorySeed.Text = seed.ToString();
			NewFactory(seed);
		}

		private void NewFactory(int seed)
		{
			factory = new MineBuilder(seed)
				.Size(MAP_SIZE, MAP_SIZE)
				.FillHoles()
				.MinimumMainArea(MAP_SIZE * MAP_SIZE / 4)
				.SelectDoors(2, 3, 40)
				.EntraceRadius(3)
				.AddOre(0.2, 0.7, 2);
			UpdateParameters();
			GenerateCave();
		}

		private void UpdateParameters()
		{
			factory.WallDensity(wallDensity.Value / 10.0)
				   .RockDensity(rockDensity.Value / 10.0);
		}

		private void GenerateCave(int seed)
		{
			map = factory.Generate(seed);
			UpdateBitmap();
		}

		private void GenerateCave()
		{
			map = factory.Generate();
			UpdateBitmap();
		}

		private void RefreshCave()
		{
			UpdateParameters();
			GenerateCave(map.Seed);
		}

		public void UpdateBitmap()
		{
			mapSeed.Text = map.Seed.ToString();

			Bitmap bmp = new Bitmap(BITMAP_SIZE, BITMAP_SIZE);
			Graphics gfx = Graphics.FromImage(bmp);

			for (int i = 0; i < MAP_SIZE; i++)
			{
				for (int j = 0; j < MAP_SIZE; j++)
				{
					Brush brush = Brushes.White;
					if (map.Terrain[i, j] >= 3) brush = Brushes.Black;
					else if (map.Terrain[i, j] == 2) brush = Brushes.Gray;
					else if (map.Terrain[i, j] == 1) brush = Brushes.LightGray;

					gfx.FillRectangle(brush, i * TILE_SIZE, j * TILE_SIZE, TILE_SIZE, TILE_SIZE);

					gfx.FillRectangle(new SolidBrush(Color.FromArgb(255 * map.GetOre(0)[i, j] / 2, 132, 55, 171)), i * TILE_SIZE + 1, j * TILE_SIZE + 1, 3, 3);
				}
			}

			if (showEdges.Checked)
			{
				foreach (Pixel p in map.MainRegion.Edge)
				{
					gfx.FillRectangle(Brushes.LightBlue, p.X * TILE_SIZE, p.Y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
				}

				foreach (Pixel p in map.MainRegion.Border)
				{
					gfx.FillRectangle(Brushes.DarkBlue, p.X * TILE_SIZE, p.Y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
				}
			}

			foreach (Segment s in map.Doors)
			{
				foreach (Pixel p in s.Pixels)
				{
					gfx.FillRectangle(Brushes.Red, p.X * TILE_SIZE, p.Y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
				}
			}

			pictureBox1.Image = bmp;
		}
	}
}
