using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class DipAnalyserTradingModeDecider : AbstractTradingModeDecider
	{
		public DipAnalyserTradingModeDecider()
		{
			Debug.WriteLine(1);
		}

		protected override void SetFinalEval()
		{
			Debug.WriteLine(1);
		}
		async protected override void CreateState()
		{
			Debug.WriteLine(1);
		}
		async private void OrderFilledCallback(object filled_order)
		{
			Debug.WriteLine(1);
		}
		async private void CreateBottomOrder(object notification_candle_time)
		{
			Debug.WriteLine(1);
		}
		async private void CreateOrderIfEnabled(object trader, object notification_candle_time)
		{
			Debug.WriteLine(1);
		}
		async private void CreateOrder(object trader, bool buy = true, object total_sell = null, object sell_target = null, object buy_price = null)
		{
			Debug.WriteLine(1);
		}
		async private void CreateSellOrders(object trader, object portfolio, object order_creator, object total_sell, object sell_target, object buy_price)
		{
			Debug.WriteLine(1);
		}
		async private void CreateBuyOrder(object trader, object portfolio, object order_creator)
		{
			Debug.WriteLine(1);
		}
		private void RegisterBuyOrder(object order)
		{
			Debug.WriteLine(1);
		}
		private void UnregisterBuyOrder(object order)
		{
			Debug.WriteLine(1);
		}
		private void GetSellTargetForRegisteredOrder(object order)
		{
			Debug.WriteLine(1);
		}
		private static void GetOrderIdentifier(object order)
		{
			Debug.WriteLine(1);
		}
		protected override void GetShouldCancelLoadedOrders(object cls)
		{
			Debug.WriteLine(1);
		}
		async private void CancelBuyOrders()
		{
			Debug.WriteLine(1);
		}
		private void GetCurrentBuyOrders(object trader)
		{
			Debug.WriteLine(1);
		}
		async private void CancelBuyOrdersForTrader(object trader)
		{
			Debug.WriteLine(1);
		}
	}
}