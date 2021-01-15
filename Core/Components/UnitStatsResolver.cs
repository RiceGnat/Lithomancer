using System;

namespace Lithomancer.Core.Components
{
	[Serializable]
	internal class UnitStatsResolver : IStats
	{
		private readonly Func<IStats> statsProvider;

		public UnitStatsResolver(Func<IStats> statsProvider) => this.statsProvider = statsProvider;

		private int Calculate(int a, int b) => a * (100 + b) / 100;

		public int this[Enum stat]
		{
			get
			{
				IStats source = statsProvider();

				switch (stat)
				{
					case UnitStat.ATK: return Calculate(source[UnitStat.ATK], source[UnitStat.ATKPercent]);
					case UnitStat.DEF: return Calculate(source[UnitStat.DEF], source[UnitStat.DEFPercent]);
					case UnitStat.HP: return Calculate(source[UnitStat.HP], source[UnitStat.HPPercent]);
					default: return source[stat];
				}
			}
		}
	}
}
