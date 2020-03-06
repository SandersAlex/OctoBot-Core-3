using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Tools;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class HighFrequencyModeDecider : AbstractTradingModeDeciderWithBot, IInitializable
	{
		public HighFrequencyModeDecider()
		{
			Debug.WriteLine(1);
		}

		async private void InitializeImpl()
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
		private void GetRequiredDifferenceFromRisk()
		{
			Debug.WriteLine(1);
		}
		async private void CreateState()
		{
			Debug.WriteLine(1);
		}
		private void CreatorCanSell(object creator_key, object current_price)
		{
			Debug.WriteLine(1);
		}
		private void RegisterCreatorMarketValue(object creator_key)
		{
			Debug.WriteLine(1);
		}
		async private void SetState(object new_state)
		{
			Debug.WriteLine(1);
		}
		private void UpdateAvailableCreators()
		{
			Debug.WriteLine(1);
		}
	}
}