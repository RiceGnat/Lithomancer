namespace Lithomancer.MapGeneration.CellularAutomata
{
	public static class RuleSets
	{
		public static RuleSet Basic => new RuleSet(0.45, true, (region, generation) => region.GetCount() > 4);
	}
}
