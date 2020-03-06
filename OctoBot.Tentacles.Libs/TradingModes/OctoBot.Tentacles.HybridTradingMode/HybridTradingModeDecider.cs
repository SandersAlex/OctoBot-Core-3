using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class HybridTradingModeDecider : AbstractTradingModeDecider
	{
		public HybridTradingModeDecider()
		{
			Debug.WriteLine(1);
		}

		protected override void SetFinalEval()
		{
			Debug.WriteLine(1);
		}
		protected override void GetShouldCancelLoadedOrders(object cls)
		{
			Debug.WriteLine(1);
		}
		protected override void CreateState()
		{
			Debug.WriteLine(1);
		}	
	}
}