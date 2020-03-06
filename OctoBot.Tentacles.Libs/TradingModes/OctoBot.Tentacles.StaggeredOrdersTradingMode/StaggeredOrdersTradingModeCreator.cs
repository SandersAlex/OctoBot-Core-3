using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class StaggeredOrdersTradingModeCreator : AbstractTradingModeCreator
	{
		public StaggeredOrdersTradingModeCreator()
		{
			Debug.WriteLine(1);
		}

		protected override void CreateNewOrder(object eval_note, object symbol, object exchange, object trader, object portfolio, object state)
		{
			Debug.WriteLine(1);
		}
		async private void CreateOrder(object order_data, object current_price, object symbol_market, object trader, object portfolio)
		{
			Debug.WriteLine(1);
		}
	}
}