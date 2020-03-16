using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Evaluator.TA
{
	public abstract class TAEvaluator : AbstractEvaluator
	{
		public TAEvaluator() : base()
		{
			Debug.WriteLine(1);
		}

		private void SetData(object data)
		{
			Debug.WriteLine(1);
		}
		private void GetIsEvaluable()
		{
			Debug.WriteLine(1);
		}
		protected override abstract void EvalImpl();
		protected override void GetConfigTentacleType(object cls)
		{
			Debug.WriteLine(1);
		}
		async private void Eval()
		{
			Debug.WriteLine(1);
		}
		async override protected void StartTask()
		{
			Debug.WriteLine(1);
		}
	}
	public abstract class MomentumEvaluator : TAEvaluator
	{
		protected override abstract void EvalImpl();
	}
	public abstract class OrderBookEvaluator : TAEvaluator
	{
		protected override abstract void EvalImpl();
	}
	public abstract class VolatilityEvaluator : TAEvaluator
	{
		protected override abstract void EvalImpl();
	}
	public abstract class TrendEvaluator : TAEvaluator
	{
		protected override abstract void EvalImpl();
	}
}