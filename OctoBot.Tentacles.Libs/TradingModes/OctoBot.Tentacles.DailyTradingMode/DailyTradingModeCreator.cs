using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class DailyTradingModeCreator : AbstractTradingModeCreator
	{
		public DailyTradingModeCreator()
		{
			Debug.WriteLine(1);
		}

		private void GetLimitPriceFromRisk(object eval_note, object trader)
		{
			Debug.WriteLine(1);
		}
		private void GetStopPriceFromRisk(object trader)
		{
			Debug.WriteLine(1);
		}
		private void GetBuyLimitQuantityFromRisk(object eval_note, object trader, object quantity, object quote)
		{
			Debug.WriteLine(1);
		}
		async private void GetSellLimitQuantityFromRisk(object eval_note, object trader, object quantity, object portfolio, object quote)
		{
			Debug.WriteLine(1);
		}
		private void GetMarketQuantityFromRisk(object eval_note, object trader, object quantity, object quote, bool selling = false)
		{
			Debug.WriteLine(1);
		}
		async private void GetQuantityRatio(object trader, object portfolio, object currency)
		{
			Debug.WriteLine(1);
		}
		async protected override void CreateNewOrder(object eval_note, object symbol, object exchange, object trader, object portfolio, object state)
		{
			Debug.WriteLine(1);
		}
	}
}