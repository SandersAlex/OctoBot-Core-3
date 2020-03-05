using System;
using System.Diagnostics;
using OctoBot.AppServices;
using OctoBot.Evaluator.Social;

namespace OctoBot.Tentacles
{
	public class TwitterNewsEvaluator : NewsSocialEvaluator, IDispatcherAbstractClient
	{
		public TwitterNewsEvaluator()
		{
			Debug.WriteLine(1);
		}

		protected override void EvalImpl()
		{
			throw new NotImplementedException();
		}

		protected override void GetData()
		{
			throw new NotImplementedException();
		}

		protected override void StartTask()
		{
			throw new NotImplementedException();
		}
	}
}
