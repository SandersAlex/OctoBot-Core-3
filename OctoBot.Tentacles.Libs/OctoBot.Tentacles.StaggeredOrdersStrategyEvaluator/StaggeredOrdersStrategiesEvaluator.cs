using System;
using System.Diagnostics;
using OctoBot.Evaluator.Strategies;

namespace OctoBot.Tentacles
{
	public class StaggeredOrdersStrategiesEvaluator : StaggeredStrategiesEvaluator
	{
		private static void GetEvalType()
		{
			Debug.WriteLine(1);
		}
		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
	}
}
