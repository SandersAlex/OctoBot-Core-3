using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Evaluator.RealTime;

namespace OctoBot.Tentacles
{
	public class InstantMAEvaluator : RealTimeExchangeEvaluator
	{
		public InstantMAEvaluator()
		{
			Debug.WriteLine(1);
		}

		async protected override void RefreshData()
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