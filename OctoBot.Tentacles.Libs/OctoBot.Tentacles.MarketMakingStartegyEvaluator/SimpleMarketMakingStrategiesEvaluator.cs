using System;
using System.Diagnostics;
using OctoBot.Evaluator.Strategies;

namespace OctoBot.Tentacles
{
	public class SimpleMarketMakingStrategiesEvaluator : MarketMakingStrategiesEvaluator
	{
		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
		private void FinalizeEvaluator()
		{
			Debug.WriteLine(1);
		}
	}
}