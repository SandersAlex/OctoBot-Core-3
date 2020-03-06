using System;
using System.Diagnostics;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class SafeProfitMode : AbstractTradingMode
	{
		public SafeProfitMode()
		{
			Debug.WriteLine(1);
		}

		protected override void CreateCreators(object symbol, object symbol_evaluator)
		{
			throw new NotImplementedException();
		}

		protected override void CreateDeciders(object symbol, object symbol_evaluator)
		{
			throw new NotImplementedException();
		}
	}
}