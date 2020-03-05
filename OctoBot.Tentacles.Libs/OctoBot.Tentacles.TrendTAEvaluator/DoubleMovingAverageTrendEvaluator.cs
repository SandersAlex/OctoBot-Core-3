using System;
using System.Diagnostics;
using OctoBot.Evaluator.TA;

namespace OctoBot.Tentacles
{
	public class DoubleMovingAverageTrendEvaluator : TrendEvaluator
	{
		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
		private void GetMovingAverageAnalysis(object data, object current_moving_average, object time_period)
		{
			Debug.WriteLine(1);
		}
	}
}
