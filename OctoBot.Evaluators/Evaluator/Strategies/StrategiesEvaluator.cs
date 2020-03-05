using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Evaluator.Strategies
{
	public abstract class StrategiesEvaluator : AbstractEvaluator
	{
		public StrategiesEvaluator() : base()
		{
			Debug.WriteLine(1);
		}

		private void SetMatrix(object matrix)
		{
			Debug.WriteLine(1);
		}
		private void GetIsEvaluable()
		{
			Debug.WriteLine(1);
		}
		private void CreateDivergenceAnalyser()
		{
			Debug.WriteLine(1);
		}
		private void GetDivergence()
		{
			Debug.WriteLine(1);
		}
		protected override abstract void EvalImpl();
		protected override void GetConfigTentacleType(object cls)
		{
			Debug.WriteLine(1);
		}
		private void GetRequiredTimeFrames(object cls, object config)
		{
			Debug.WriteLine(1);
		}
		private void GetRequiredEvaluators(object cls, object config, object strategy_config = null)
		{
			Debug.WriteLine(1);
		}
		private void GetDefaultEvaluators(object cls, object config)
		{
			Debug.WriteLine(1);
		}
		async protected override void StartTask()
		{
			Debug.WriteLine(1);
		}
	}
	public abstract class MixedStrategiesEvaluator : StrategiesEvaluator
	{
		protected override abstract void EvalImpl();
	}
	public abstract class MarketMakingStrategiesEvaluator : StrategiesEvaluator
	{
		protected override abstract void EvalImpl();
	}
	public abstract class StaggeredStrategiesEvaluator : StrategiesEvaluator
	{
		protected override abstract void EvalImpl();
	}
}