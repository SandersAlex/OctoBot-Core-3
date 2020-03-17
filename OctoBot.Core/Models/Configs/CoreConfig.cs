using System;
using System.Collections.Generic;
using System.Text;

namespace OctoBot.Core
{
	internal class CoreConfig : ICoreConfig
	{
		public bool Debug { get; set; }
		public bool? DevMode { get; set; }
		public bool Perf { get; set; }
		public bool SaveEvaluations { get; set; }
		public bool PerformanceAnalyser { get; set; }
		public bool AcceptedTerms { get; set; }
		public Backtesting Backtesting { get; set; }
		public Dictionary<string, PairsList> CryptoCurrencies { get; set; }
		public Dictionary<string, Exchange> Exchanges { get; set; }
		public DataCollector DataCollector { get; set; }
		public Metrics Metrics { get; set; }
		public Notification Notification { get; set; }
		public Dictionary<string, object> Services { get; set; }
		public List<string>? TentaclesPackages { get; set; }
		public Trader Trader { get; set; }
		public TraderSimulator TraderSimulator { get; set; }
		public Trading Trading { get; set; }
		public List<string> WatchedSymbols { get; set; }
		public Dictionary<string, object> AdvancedClasses { get; set; }
		public List<Type> Evaluator { get; set; }

		public CoreConfig()
		{
			Backtesting = new Backtesting();
			CryptoCurrencies = new Dictionary<string, PairsList>();
			Exchanges = new Dictionary<string, Exchange>();
			DataCollector = new DataCollector();
			Metrics = new Metrics();
			Notification = new Notification();
			Services = new Dictionary<string, object>();
			Trader = new Trader();
			TraderSimulator = new TraderSimulator();
			Trading = new Trading();
			WatchedSymbols = new List<string>();
			AdvancedClasses = new Dictionary<string, object>();
			Evaluator = new List<Type>();
		}
	}
	public class Backtesting
	{
		public bool PostAnalysisEnabled { get; set; }
		public bool Enabled { get; set; }
		public List<string> Files { get; set; } = new List<string>();
	}
	public class PairsList
	{
		public List<string> Pairs { get; set; } = new List<string>();
		public string Quote { get; set; }
	}
	public class DataCollector
	{
		public string Symbol { get; set; }
	}
	public class Metrics
	{
		public bool Enabled { get; set; }
		public string MetricsBotId { get; set; }
	}
	public class Notification
	{
		public bool Enabled { get; set; }
		public bool GlobalInfo { get; set; }
		public bool PriceAlerts { get; set; }
		public bool Trades { get; set; }
		public List<string> NotificationType { get; set; } = new List<string>();
	}
	public class Trader
	{
		public bool Enabled { get; set; }
	}
	public class TraderSimulator
	{
		public bool Enabled { get; set; }
		public Fees Fees { get; set; } = new Fees();
		public Dictionary<string, decimal> StartingPortfolio { get; set; } = new Dictionary<string, decimal>();
	}
	public class Fees
	{
		public decimal Maker { get; set; }
		public decimal Taker { get; set; }
	}
	public class Trading
	{
		public bool MultiSessionProfitability { get; set; }
		public string ReferenceMarket { get; set; }
		public decimal Risk { get; set; }
	}
}