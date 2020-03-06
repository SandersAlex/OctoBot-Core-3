using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class ObjectiveModeDecider : AbstractTradingModeDecider
	{
		public ObjectiveModeDecider()
		{
			Debug.WriteLine(1);
		}

		protected override void CreateState()
		{
			throw new NotImplementedException();
		}

		protected override void GetShouldCancelLoadedOrders(object cls)
		{
			throw new NotImplementedException();
		}

		protected override void SetFinalEval()
		{
			throw new NotImplementedException();
		}
	}
}