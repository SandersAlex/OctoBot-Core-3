using System;
using System.Diagnostics;

namespace OctoBot.Tradings
{
	public abstract class AbstractTradingModeCreator
	{
		public AbstractTradingModeCreator()
		{
			Debug.WriteLine(1);
		}

		private void GetCurrentLogger(object cls)
		{
			Debug.WriteLine(1);
		}
		private static void CheckFactor(object min_val, object max_val, object factor)
		{
			Debug.WriteLine(1);
		}
		private static void IsValid(object element, object key)
		{
			Debug.WriteLine(1);
		}
		private static void AddDustsToQuantityIfNecessary(object quantity, object price, object symbol_market, object current_symbol_holding)
		{
			Debug.WriteLine(1);
		}
		private static void CheckCost(object total_order_price, object min_cost)
		{
			Debug.WriteLine(1);
		}
		private static void SplitOrders(object total_order_price, object max_cost, object valid_quantity, object max_quantity, object price, object quantity, object symbol_market)
		{
			Debug.WriteLine(1);
		}
		private static void GetMinMaxAmounts(object symbol_market, object default_value = null)
		{
			Debug.WriteLine(1);
		}
		private static void CheckAndAdaptOrderDetailsIfNecessary(object quantity, object price, object symbol_market, bool fixed_symbol_data = false)
		{
			Debug.WriteLine(1);
		}
		async private static void GetHoldingsRatio(object trader, object portfolio, object currency)
		{
			Debug.WriteLine(1);
		}
		private static void GetNumberOfTradedAssets(object trader)
		{
			Debug.WriteLine(1);
		}
		async private static void CanCreateOrder(object symbol, object exchange, object state, object portfolio)
		{
			Debug.WriteLine(1);
		}
		async private static void GetPreOrderData(object exchange, object symbol, object portfolio)
		{
			Debug.WriteLine(1);
		}
		protected abstract void CreateNewOrder(object eval_note, object symbol, object exchange, object trader, object portfolio, object state);
		private static void AdaptPrice(object symbol_market, object price)
		{
			Debug.WriteLine(1);
		}
		private static void AdaptQuantity(object symbol_market, object quantity)
		{
			Debug.WriteLine(1);
		}
		private static void TruncWithAndDecimalDigits(object value, object digits)
		{
			Debug.WriteLine(1);
		}
		private static void AdaptOrderQuantityBecauseQuantity(object limiting_value, object max_value, object quantity_to_adapt, object price, object symbol_market)
		{
			Debug.WriteLine(1);
		}
		private static void AdaptOrderQuantityBecausePrice(object limiting_value, object max_value, object price, object symbol_market)
		{
			Debug.WriteLine(1);
		}
	}
}