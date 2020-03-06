using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class HighFrequencyModeCreator : AbstractTradingModeCreatorWithBot
	{
		public HighFrequencyModeCreator()
		{
			Debug.WriteLine(1);
		}

		async protected override void CreateNewOrder(object eval_note, object symbol, object exchange, object trader, object portfolio, object state)
		{
			Debug.WriteLine(1);
		}
		private void SetMarketValue(object market_value)
		{
			Debug.WriteLine(1);
		}
		private void GetMarketValue()
		{
			Debug.WriteLine(1);
		}
	}
}