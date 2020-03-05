using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Evaluator.TA;

namespace OctoBot.Tentacles
{
	public class MACDMomentumEvaluator : MomentumEvaluator
	{
		public MACDMomentumEvaluator()
		{
			Debug.WriteLine(1);
		}

		private void AnalysePattern(object pattern, object macd_hist, object zero_crossing_indexes, object price_weight, object pattern_move_time, object sign_multiplier)
		{
			Debug.WriteLine(1);
		}
		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
	}
}
