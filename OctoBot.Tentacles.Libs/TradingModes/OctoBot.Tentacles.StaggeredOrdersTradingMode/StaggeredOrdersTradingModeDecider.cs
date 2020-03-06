using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class StaggeredOrdersTradingModeDecider : AbstractTradingModeDecider
	{
		public StaggeredOrdersTradingModeDecider()
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
		async private void HandleStaggeredOrders(object final_eval, object trader)
		{
			Debug.WriteLine(1);
		}
		async private void GenerateStaggeredOrders(object current_price, object trader)
		{
			Debug.WriteLine(1);
		}
		private void GetInterferingOrdersPairs(object orders)
		{
			Debug.WriteLine(1);
		}
		private void CheckParams()
		{
			Debug.WriteLine(1);
		}
		private void AnalyseCurrentOrdersSituation(object sorted_orders, object recently_closed_orders)
		{
			Debug.WriteLine(1);
		}
		private void CreateOrders(object lower_bound, object upper_bound, object side, object sorted_orders, object portfolio, object current_price, object missing_orders, object state)
		{
			Debug.WriteLine(1);
		}
		private void BootstrapParameters(object sorted_orders, object recently_closed_orders)
		{
			Debug.WriteLine(1);
		}
		private void IsJustClosedOrder(object price, object sorted_closed_orders)
		{
			Debug.WriteLine(1);
		}
		private static void SpreadInRecentlyClosedOrder(object min_amount, object max_amount, object sorted_closed_orders)
		{
			Debug.WriteLine(1);
		}
		private static void AlternateNotVirtualOrders(object buy_orders, object sell_orders)
		{
			Debug.WriteLine(1);
		}
		private static void FilterVirtualOrder(object orders)
		{
			Debug.WriteLine(1);
		}
		private static void SetVirtualOrders(object buy_orders, object sell_orders, object operational_depth)
		{
			Debug.WriteLine(1);
		}
		private void GetOrderCountAndAverageQuantity(object current_price, object selling, object lower_bound, object upper_bound, object holdings, object currency = null)
		{
			Debug.WriteLine(1);
		}
		private void GetPriceFromIteration(object starting_bound, object is_selling, object iteration)
		{
			Debug.WriteLine(1);
		}
		private void GetQuantityFromIteration(object average_order_quantity, object mode, object side, object iteration, object max_iteration, object price)
		{
			Debug.WriteLine(1);
		}
		private void GetMinFunds(object orders_count, object min_order_quantity, object mode, object current_price)
		{
			Debug.WriteLine(1);
		}
		private static void GetMinMaxQuantity(object average_order_quantity, object mode)
		{
			Debug.WriteLine(1);
		}
		async private void CreateMultipleNotVirtualOrders(object orders_to_create, object trader)
		{
			Debug.WriteLine(1);
		}
		async private void CreateOrder(object order, object trader, object order_creator, object new_orders, object portfolio, bool retry = true)
		{
			Debug.WriteLine(1);
		}
		async private void CreateNotVirtualOrders(object notifier, object trader, object orders_to_create, object creator_key)
		{
			Debug.WriteLine(1);
		}
		private void RefreshSymbolData()
		{
			Debug.WriteLine(1);
		}
		protected override void GetShouldCancelLoadedOrders(object cls)
		{
			Debug.WriteLine(1);
		}
		private void GetLock()
		{
			Debug.WriteLine(1);
		}
	}
}