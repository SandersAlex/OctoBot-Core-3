using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Force.DeepCloner;
using OctoBot.Config;

namespace OctoBot.Core
{
	/// <summary>
	/// """Main OctoBot class:
	/// - Create all indicators and thread for each cryptocurrencies in config """
	/// </summary>
	public class OctoBot
	{
		private DateTimeOffset StartTime { get; set; }
		private ICoreConfig Config { get; set; }
		private ICoreConfig StartupConfig { get; set; }
		private ICoreConfig EditedConfig { get; set; }
		private bool ResetTradingHistory { get; set; }

		private Dictionary<string, object> Tools { get; set; }
		private object AioHttpSession { get; set; }
		private object MetricsHandler { get; set; }

		private ILoggingService loggingService { get; set; }

		private Initializer Initializer { get; set; }
		private TaskManager TaskManager { get; set; }
		private ExchangeFactory ExchangeFactory { get; set; }
		private EvaluatorFactory EvaluatorFactory { get; set; }

		public OctoBot(ICoreConfig config, bool ignoreConfig = false, bool resetTradingHistory = false)
		{
			StartTime = DateTimeOffset.Now;
			Config = config;
			ResetTradingHistory = resetTradingHistory;
			StartupConfig = config.DeepClone();
			EditedConfig = config.DeepClone();

			// tools: используется для альтернативных операций в ботом на лету (например, «backtesting» запускается из веб-интерфейса)
			Tools = new Dictionary<string, object>()
			{
				{ ConfigVars.BOT_TOOLS_BACKTESTING, null },
				{ ConfigVars.BOT_TOOLS_STRATEGY_OPTIMIZER, null },
				{ ConfigVars.BOT_TOOLS_RECORDER, null }
			};

			// уникальное значение сеанса aiohttp: инициализируется из геттера в задаче
			AioHttpSession = null;

			// metrics если включены
			MetricsHandler = null;

			// Logger
			loggingService = Application.Resolve<ILoggingService>();

			Initializer = new Initializer(this);
			TaskManager = new TaskManager(this);
			ExchangeFactory = new ExchangeFactory(this, ignoreConfig);
			EvaluatorFactory = new EvaluatorFactory(this);
		}

		async public Task Initialize()
		{
			Debug.WriteLine(1);
		}
		async public Task Start(bool runInNewThread = false)
		{
			Debug.WriteLine(1);
		}
		private void Stop()
		{
			Debug.WriteLine(1);
		}
		private void RunInMainAsyncioLoop(object coroutine)
		{
			Debug.WriteLine(1);
		}
		private void SetWatcher(object watcher)
		{
			Debug.WriteLine(1);
		}
		private void GetSymbolsTasksManager()
		{
			Debug.WriteLine(1);
		}
		private void GetExchangeTraders()
		{
			Debug.WriteLine(1);
		}
		private void GetExchangeTraderSimulators()
		{
			Debug.WriteLine(1);
		}
		private void GetExchangeTradingModes()
		{
			Debug.WriteLine(1);
		}
		private void GetExchangesList()
		{
			Debug.WriteLine(1);
		}
		private void GetSymbolEvaluatorList()
		{
			Debug.WriteLine(1);
		}
		private void GetSymbolsList()
		{
			Debug.WriteLine(1);
		}
		private void GetCryptoCurrencyEvaluatorList()
		{
			Debug.WriteLine(1);
		}
		private void GetDispatchersList()
		{
			Debug.WriteLine(1);
		}
		private void GetGlobalUpdatersByExchange()
		{
			Debug.WriteLine(1);
		}
		private void GetTradingMode()
		{
			Debug.WriteLine(1);
		}
		public bool IsReady()
		{
			return TaskManager.Ready;
		}
		private void GetConfig()
		{
			Debug.WriteLine(1);
		}
		private void GetTools()
		{
			Debug.WriteLine(1);
		}
		private void GetTimeFrames()
		{
			Debug.WriteLine(1);
		}
		private void GetRelevantEvaluators()
		{
			Debug.WriteLine(1);
		}
		private void GetAsyncLoop()
		{
			Debug.WriteLine(1);
		}
		private void GetAioHttpSession()
		{
			Debug.WriteLine(1);
		}
	}
}