using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Core
{
	/// <summary>
	/// """ExchangeFactory class:
	/// - Create exchanges and trades according to configureated exchanges """
	/// </summary>
	internal class ExchangeFactory
	{
		private OctoBot Octobot { get; set; }
		private bool IgnoreConfig { get; set; }

		private ILoggingService loggingService { get; set; }

		private Dictionary<string, object> ExchangeTraders { get; set; }
		private Dictionary<string, object> ExchangeTraderSimulators { get; set; }
		private Dictionary<string, object> ExchangeTradingModes { get; set; }
		private object TradingMode { get; set; }
		private object PreviousTradingStateManager { get; set; }
		private Dictionary<string, object> ExchangesList { get; set; }
		private Dictionary<string, object> GlobalUpdatersByExchange { get; set; }
		private List<string> AvailableExchanges { get; set; }

		public ExchangeFactory(OctoBot octobot, bool ignoreConfig = false)
		{
			Octobot = octobot;
			IgnoreConfig = ignoreConfig;

			// Logger
			loggingService = Application.Resolve<ILoggingService>();

			ExchangeTraders = new Dictionary<string, object>();
			ExchangeTraderSimulators = new Dictionary<string, object>();
			ExchangeTradingModes = new Dictionary<string, object>();
			TradingMode = null;
			PreviousTradingStateManager = null;
			ExchangesList = new Dictionary<string, object>();
			GlobalUpdatersByExchange = new Dictionary<string, object>();

			AvailableExchanges = new List<string>() { "binance" };
		}

		async private void Create()
		{
			Debug.WriteLine(1);
		}
		private void CreatePreviousStateManager()
		{
			Debug.WriteLine(1);
		}
		async private void CreateExchangeTraders(object exchange_class_string)
		{
			Debug.WriteLine(1);
		}
		private void CreateExchangeInstances(object exchange_manager)
		{
			Debug.WriteLine(1);
		}
		private void CreateGlobalPriceUpdater(object exchange_inst)
		{
			Debug.WriteLine(1);
		}
		private void CreateExchangeManager(object exchange_type)
		{
			Debug.WriteLine(1);
		}
		async private void CreateTrader(object trader_class, object exchange_inst)
		{
			Debug.WriteLine(1);
		}
		async private void CreateTraders(object exchange_inst)
		{
			Debug.WriteLine(1);
		}
		private void IsMinimumTradersActivated(object exchange_inst)
		{
			Debug.WriteLine(1);
		}
		private void CreateTradingMode(object exchange_inst)
		{
			Debug.WriteLine(1);
		}
		private void RegisterTradingModeWithTrader(object trader)
		{
			Debug.WriteLine(1);
		}
		private void RegisterTradingModeOnTraders(object exchange_inst)
		{
			Debug.WriteLine(1);
		}
	}
}