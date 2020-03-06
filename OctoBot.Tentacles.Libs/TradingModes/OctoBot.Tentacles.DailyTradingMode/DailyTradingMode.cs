using System;
using System.Diagnostics;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class DailyTradingMode : AbstractTradingMode
	{
		public DailyTradingMode()
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
	}
}
