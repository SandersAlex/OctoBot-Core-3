using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Evaluator.Social;

namespace OctoBot.Tentacles
{
	public class MediumNewsEvaluator : NewsSocialEvaluator
	{
		protected override void GetData()
		{
			Debug.WriteLine(1);
		}
		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
		protected override void StartTask()
		{
			Debug.WriteLine(1);
		}
		private void SetDefaultConfig()
		{
			Debug.WriteLine(1);
		}
	}
}