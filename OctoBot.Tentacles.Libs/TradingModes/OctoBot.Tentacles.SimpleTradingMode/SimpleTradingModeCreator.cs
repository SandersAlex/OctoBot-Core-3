using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class SimpleTradingModeCreator : AbstractTradingModeCreator
	{
		public SimpleTradingModeCreator()
		{
			Debug.WriteLine(1);
		}

		protected override void CreateNewOrder(object eval_note, object symbol, object exchange, object trader, object portfolio, object state)
		{
			Debug.WriteLine(1);
		}
	}
}