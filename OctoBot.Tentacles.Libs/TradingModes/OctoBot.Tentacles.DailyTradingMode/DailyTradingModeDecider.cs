using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class DailyTradingModeDecider : AbstractTradingModeDecider
	{
		public DailyTradingModeDecider()
		{
			Debug.WriteLine(1);
		}

		protected override void SetFinalEval()
		{
			Debug.WriteLine(1);
		}
		private void GetDeltaRisk()
		{
			Debug.WriteLine(1);
		}
		async protected override void CreateState()
		{
			Debug.WriteLine(1);
		}
		protected override void GetShouldCancelLoadedOrders(object cls)
		{
			Debug.WriteLine(1);
		}
		async private void SetState(object new_state)
		{
			Debug.WriteLine(1);
		}
	}
}