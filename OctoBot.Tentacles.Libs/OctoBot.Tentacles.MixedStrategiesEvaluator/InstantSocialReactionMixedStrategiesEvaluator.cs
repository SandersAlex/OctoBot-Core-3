using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Evaluator.Strategies;

namespace OctoBot.Tentacles
{
	public class InstantSocialReactionMixedStrategiesEvaluator : MixedStrategiesEvaluator
	{
		public InstantSocialReactionMixedStrategiesEvaluator()
		{
			Debug.WriteLine(1);
		}

		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
		private void IncSocialCounter(int inc = 1)
		{
			Debug.WriteLine(1);
		}
		private void IncInstantCounter(int inc = 1)
		{
			Debug.WriteLine(1);
		}		
		private void FinalizeEvaluator()
		{
			Debug.WriteLine(1);
		}
	}
}
