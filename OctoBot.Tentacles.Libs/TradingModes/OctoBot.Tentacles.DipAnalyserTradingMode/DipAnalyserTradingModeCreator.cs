using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class DipAnalyserTradingModeCreator : AbstractTradingModeCreator
	{
		public DipAnalyserTradingModeCreator()
		{
			Debug.WriteLine(1);
		}

		async private void CreateBuyOrder(object volume_weight, object trader, object portfolio, object symbol, object exchange)
		{
			Debug.WriteLine(1);
		}
		async private void CreateSellOrders(object sell_orders_count, object trader, object portfolio, object symbol, object exchange, object quantity, object sell_weight, object sell_base)
		{
			Debug.WriteLine(1);
		}
		async private void GetBuyQuantityFromWeight(object volume_weight, object trader, object market_quantity, object portfolio, object currency)
		{
			Debug.WriteLine(1);
		}
		private static void GetLimitPrice(object price)
		{
			Debug.WriteLine(1);
		}
		private void GenerateSellOrders(object sell_orders_count, object quantity, object sell_weight, object sell_base, object symbol_market)
		{
			Debug.WriteLine(1);
		}
		private void CheckLimits(object sell_base, object sell_max, object quantity, object sell_orders_count, object symbol_market)
		{
			Debug.WriteLine(1);
		}
		private static void EnsureOrdersSize(object sell_base, object sell_max, object quantity, object sell_orders_count, object min_quantity, object min_cost, object min_price, object max_quantity, object max_cost, object max_price)
		{
			Debug.WriteLine(1);
		}
		private static void OrdersTooSmall(object min_quantity, object min_cost, object min_price, object sell_price, object sell_vol)
		{
			Debug.WriteLine(1);
		}
		private static void OrdersTooLarge(object max_quantity, object max_cost, object max_price, object sell_price, object sell_vol)
		{
			Debug.WriteLine(1);
		}
		protected override void CreateNewOrder(object eval_note, object symbol, object exchange, object trader, object portfolio, object state)
		{
			Debug.WriteLine(1);
		}
	}
}