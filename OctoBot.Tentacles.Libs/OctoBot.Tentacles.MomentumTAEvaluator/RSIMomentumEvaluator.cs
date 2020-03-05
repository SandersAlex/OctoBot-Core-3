using System;
using System.Diagnostics;
using OctoBot.Evaluator.TA;

namespace OctoBot.Tentacles
{
	public class RSIMomentumEvaluator : MomentumEvaluator
	{
		public RSIMomentumEvaluator()
		{
			Debug.WriteLine(1);
		}

		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
	}
}
