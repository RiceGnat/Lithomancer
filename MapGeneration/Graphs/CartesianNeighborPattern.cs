namespace Lithomancer.MapGeneration.Graphs
{
	public struct CartesianNeighborPattern
	{
		private readonly byte bitmask;

		public CartesianNeighborPattern(byte pattern) => bitmask = pattern;
		public CartesianNeighborPattern(int pattern) : this((byte)pattern) { }

		private byte CircularBitShift(int shift) => (byte)((bitmask >> shift) | (bitmask << (8 - shift)));
		private byte RotateBits(int rotation) => CircularBitShift(rotation % 4 * 2);

		public CartesianNeighborPattern Rotate(int rotation) => new CartesianNeighborPattern(RotateBits(rotation));

		public byte GetSide(int side) => (byte)(RotateBits(side) & 0b111);

		public byte GetCenter(int rotation)
		{
			byte rotated = RotateBits(rotation);
			return (byte)(((rotated >> 5) & 0b100) | 0b10 | (rotated >> 3 & 0b1));
		}

		public ushort ConnectsWith(CartesianNeighborPattern pattern)
		{
			int connections = 0;
			for (int i = 0; i < 4; i++)
			{
				byte side = GetSide(i);
				byte center = GetCenter(i);
				for (int j = 0; j < 4; j++)
				{
					byte otherSide = pattern.GetSide(j);
					byte otherCenter = pattern.GetCenter(j);
					if (side == otherCenter && otherSide == center)
					{
						connections |= 1 << (i * 4 + j);
					}
				}
			}

			return (ushort)connections;
		}

		public byte IsRotation(CartesianNeighborPattern pattern)
		{
			int rotations = 0;
			for (int i = 0; i < 4; i++)
			{
				if (Rotate(i) == pattern)
				{
					rotations |= 1 << i;
				}
			}

			return (byte)rotations;
		}

		public override bool Equals(object obj) => obj is CartesianNeighborPattern pattern && bitmask == pattern.bitmask;
		public override int GetHashCode() => 186907304 + bitmask.GetHashCode();

		public static bool operator ==(CartesianNeighborPattern left, CartesianNeighborPattern right) => left.Equals(right);
		public static bool operator !=(CartesianNeighborPattern left, CartesianNeighborPattern right) => !(left == right);
	}
}
