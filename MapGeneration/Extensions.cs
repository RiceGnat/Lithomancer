using System;

namespace Lithomancer.MapGeneration
{
	public static class Extensions
	{
		public static bool CheckBounds(this bool[,] array, int x, int y) =>
			!(x < array.GetLowerBound(0) || x > array.GetUpperBound(0) ||
			y < array.GetLowerBound(1) || y > array.GetUpperBound(1));

		public static double Lerp(this double t, double a, double b)
		{
			t.EnforceNormalized(nameof(t));

			return a * (1 - t) + b * t;
		}

		public static int DistanceTo(this (int X, int Y) point, (int X, int Y) destination) =>
			Math.Abs(destination.X - point.X) + Math.Abs(destination.Y - point.Y);

		public static bool IsNormalized(this double value) => value >= 0 && value <= 1;

		public static void EnforceNormalized(this double value, string paramName)
		{
			if (!value.IsNormalized()) throw new ArgumentOutOfRangeException(paramName, value, "Must be a normalized value");
		}
		
		public static void EnforceRange(this int value, int min, int max, string paramName)
		{
			if (value < min || value > max) throw new ArgumentOutOfRangeException(paramName, value, $"Must be in range {min} to {max}");
		}
	}
}
