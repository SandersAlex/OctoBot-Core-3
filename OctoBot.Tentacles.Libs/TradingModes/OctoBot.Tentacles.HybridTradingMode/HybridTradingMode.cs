using System;
using System.Diagnostics;
using OctoBot.Tradings;

namespace OctoBot.Tentacles
{
	public class HybridTradingMode : AbstractTradingMode
	{
		public HybridTradingMode()
		{
			Debug.WriteLine(1);
		}

		private void GetRequiredStrategies()
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