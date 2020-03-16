using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Tradings
{
	public abstract class AbstractTradingModeDecider
	{
		public AbstractTradingModeDecider()
		{
			Debug.WriteLine(1);
		}

		async private void CreateFinalStateOrders(object evaluator_notification, object creator_key)
		{
			Debug.WriteLine(1);
		}
		async private void CancelSymbolOpenOrders()
		{
			Debug.WriteLine(1);
		}
		private void ActivateDeactivateStrategies(object strategy_list, object activate)
		{
			Debug.WriteLine(1);
		}
		private void GetState()
		{
			Debug.WriteLine(1);
		}
		private void GetFinalEval()
		{
			Debug.WriteLine(1);
		}
		async private void FinalizeTrading()
		{
			Debug.WriteLine(1);
		}
		private void GetStrategyEvaluation(object strategy_class)
		{
			Debug.WriteLine(1);
		}
		protected abstract void GetShouldCancelLoadedOrders(object cls);
		protected abstract void SetFinalEval();
		protected abstract void CreateState();
		async private void CreateOrderIfPossible(object evaluator_notification, object trader, object creator_key)
		{
			Debug.WriteLine(1);
		}
		async private static void PushOrderNotificationIfPossible(object order_list, object notification)
		{
			Debug.WriteLine(1);
		}
	}
}