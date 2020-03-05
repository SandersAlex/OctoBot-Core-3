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
		public Backtesting Backtesting { get; set; } = new Backtesting();
		public Dictionary<string, PairsList> CryptoCurrencies { get; set; } = new Dictionary<string, PairsList>();
		public Dictionary<string, Exchange> Exchanges { get; set; } = new Dictionary<string, Exchange>();
		public DataCollector DataCollector { get; set; } = new DataCollector();
		public Metrics Metrics { get; set; } = new Metrics();
		public Notification Notification { get; set; } = new Notification();
		public Dictionary<string, object> Services { get; set; } = new Dictionary<string, object>();
		public List<string>? TentaclesPackages { get; set; }
		public Trader Trader { get; set; } = new Trader();
		public TraderSimulator TraderSimulator { get; set; } = new TraderSimulator();
		public Trading Trading { get; set; } = new Trading();
		public List<string> WatchedSymbols { get; set; } = new List<string>();
	}
	public class Backtesting
	{
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