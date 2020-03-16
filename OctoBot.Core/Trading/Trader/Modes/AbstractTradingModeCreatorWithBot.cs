using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tools;

namespace OctoBot.Tradings
{
	public abstract class AbstractTradingModeCreatorWithBot : AbstractTradingModeCreator, IInitializable
	{
		public AbstractTradingModeCreatorWithBot()
		{
			Debug.WriteLine(1);
		}

		async private void InitializeImpl()
		{
			Debug.WriteLine(1);
		}
		protected override abstract void CreateNewOrder(object eval_note, object symbol, object exchange, object trader, object portfolio, object state);
		private void GetTrader()
		{
			Debug.WriteLine(1);
		}
		private void GetParentPortfolio()
		{
			Debug.WriteLine(1);
		}
		private void GetSubPortfolio()
		{
			Debug.WriteLine(1);
		}
		async private void CanCreateOrder(object symbol, object exchange, object state, object portfolio)
		{
			Debug.WriteLine(1);
		}
		private void GetPortfolio(bool force_update = false)
		{
			Debug.WriteLine(1);
		}
	}
}