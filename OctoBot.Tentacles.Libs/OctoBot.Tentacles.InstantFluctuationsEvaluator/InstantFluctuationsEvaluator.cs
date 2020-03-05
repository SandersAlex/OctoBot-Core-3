using System;
using System.Diagnostics;
using OctoBot.Evaluator.RealTime;

namespace OctoBot.Tentacles
{
	public class InstantFluctuationsEvaluator : RealTimeExchangeEvaluator
	{
		public InstantFluctuationsEvaluator()
		{
			Debug.WriteLine(1);
		}

		async protected override void RefreshData()
		{
			Debug.WriteLine(1);
		}
		private void Reset()
		{
			Debug.WriteLine(1);
		}
		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
		private void EvaluateVolumeFluctuations()
		{
			Debug.WriteLine(1);
		}
		async private void Update()
		{
			Debug.WriteLine(1);
		}
		protected override void ShouldEval()
		{
			Debug.WriteLine(1);
		}
	}
}
