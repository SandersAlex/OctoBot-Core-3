using System;
using System.Diagnostics;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class StaggeredOrdersTradingMode : AbstractTradingMode
	{
		public StaggeredOrdersTradingMode()
		{
			Debug.WriteLine(1);
		}

		private static void IsBacktestable()
		{
			Debug.WriteLine(1);
		}
		protected override void CreateDeciders(object symbol, object symbol_evaluator)
		{
			Debug.WriteLine(1);
		}
		protected override void CreateCreators(object symbol, object symbol_evaluator)
		{
			Debug.WriteLine(1);
		}
		async private void OrderFilledCallback(object order)
		{
			Debug.WriteLine(1);
		}
		private void SetDefaultConfig()
		{
			Debug.WriteLine(1);
		}
	}
}