using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.TentaclesManagement;

namespace OctoBot.Tradings
{
	public abstract class AbstractTradingMode : AbstractTentacle
	{
		public AbstractTradingMode()
		{
			Debug.WriteLine(1);
		}

		protected override void GetTentacleFolder(object cls)
		{
			Debug.WriteLine(1);
		}
		protected override void GetConfigTentacleType(object cls)
		{
			Debug.WriteLine(1);
		}
		async private void OrderFilledCallback(object order)
		{
			Debug.WriteLine(1);
		}
		private static void IsBacktestable()
		{
			Debug.WriteLine(1);
		}
		private void GetRequiredStrategiesCount(object cls, object config)
		{
			Debug.WriteLine(1);
		}
		private void GetRequiredStrategies(object cls, object trading_mode_config = null)
		{
			Debug.WriteLine(1);
		}
		private void GetRequiredStrategiesNamesAndCount(object cls, object trading_mode_config = null)
		{
			Debug.WriteLine(1);
		}
		private void GetDefaultStrategies(object cls)
		{
			Debug.WriteLine(1);
		}
		protected abstract void CreateDeciders(object symbol, object symbol_evaluator);
		protected abstract void CreateCreators(object symbol, object symbol_evaluator);
		async private void OrderUpdateCallback(object order)
		{
			Debug.WriteLine(1);
		}
		private void AddSymbolEvaluator(object symbol_evaluator)
		{
			Debug.WriteLine(1);
		}
		private void GetStrategyInstancesByClasses(object symbol)
		{
			Debug.WriteLine(1);
		}
		private void InitStrategiesInstances(object symbol, object all_strategy_instances)
		{
			Debug.WriteLine(1);
		}
		private void LoadConfig()
		{
			Debug.WriteLine(1);
		}
		private void GetTradingConfigValue(object key)
		{
			Debug.WriteLine(1);
		}
		private void SetDefaultConfig()
		{
			Debug.WriteLine(1);
		}
		private void AddDecider(object symbol, object decider, object decider_key = null)
		{
			Debug.WriteLine(1);
		}
		private void AddCreator(object symbol, object creator, object creator_key = null)
		{
			Debug.WriteLine(1);
		}
		private void GetParentTradingModeClasses(object cls, object higher_parent_class_limit = null)
		{
			Debug.WriteLine(1);
		}
		private void GetCreator(object symbol, object creator_key)
		{
			Debug.WriteLine(1);
		}
		private void GetCreators(object symbol)
		{
			Debug.WriteLine(1);
		}
		private void GetOnlyCreatorKey(object symbol)
		{
			Debug.WriteLine(1);
		}
		private void GetOnlyDeciderKey(object symbol, bool with_keys = false)
		{
			Debug.WriteLine(1);
		}
		private void GetDecider(object symbol, object decider_key)
		{
			Debug.WriteLine(1);
		}
		private void GetDeciders(object symbol, bool with_keys = false)
		{
			Debug.WriteLine(1);
		}
	}
}
