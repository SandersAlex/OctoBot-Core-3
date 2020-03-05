using System;
using System.Diagnostics;
using OctoBot.Evaluator.RealTime;

namespace OctoBot.Tentacles
{
	public class WhalesOrderBookEvaluator : RealTimeExchangeEvaluator
	{
		protected override void RefreshData()
		{
			Debug.WriteLine(1);
		}
		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
		private void SetDefaultConfig()
		{
			Debug.WriteLine(1);
		}
		protected override void ShouldEval()
		{
			Debug.WriteLine(1);
		}
	}
}
