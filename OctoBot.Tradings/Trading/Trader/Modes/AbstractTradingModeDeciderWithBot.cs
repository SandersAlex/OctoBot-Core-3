using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Tradings
{
	public class AbstractTradingModeDeciderWithBot : AbstractTradingModeDecider
	{
		public AbstractTradingModeDeciderWithBot()
		{
			Debug.WriteLine(1);
		}

		protected override void GetShouldCancelLoadedOrders(object cls)
		{
			Debug.WriteLine(1);
		}
		protected override void SetFinalEval()
		{
			Debug.WriteLine(1);
		}
		protected override void CreateState()
		{
			Debug.WriteLine(1);
		}
		private void GetCreators()
		{
			Debug.WriteLine(1);
		}
		private void GetTrader()
		{
			Debug.WriteLine(1);
		}
	}
}