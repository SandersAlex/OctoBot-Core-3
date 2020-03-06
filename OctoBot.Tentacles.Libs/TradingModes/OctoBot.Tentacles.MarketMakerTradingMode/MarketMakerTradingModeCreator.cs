using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class MarketMakerTradingModeCreator : AbstractTradingModeCreator
	{
		public MarketMakerTradingModeCreator()
		{
			Debug.WriteLine(1);
		}

		private void VerifyAndAdaptDeltaWithFees(object symbol)
		{
			Debug.WriteLine(1);
		}
		private void GetQuantityFromRisk(object trader, object quantity)
		{
			Debug.WriteLine(1);
		}
		async private static void CanCreateOrder(object symbol, object exchange, object state, object portfolio)
		{
			Debug.WriteLine(1);
		}
		async protected override void CreateNewOrder(object eval_note, object symbol, object exchange, object trader, object portfolio, object state)
		{
			Debug.WriteLine(1);
		}
	}
}