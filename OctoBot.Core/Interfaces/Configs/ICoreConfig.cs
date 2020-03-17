using System;
using System.Collections.Generic;
using System.Text;

namespace OctoBot.Core
{
	public interface ICoreConfig
	{
		bool Debug { get; }
		bool? DevMode { get; }
		bool Perf { get; }
		bool SaveEvaluations { get; }
		bool PerformanceAnalyser { get; }
		bool AcceptedTerms { get; }
		Backtesting Backtesting { get; }
		Dictionary<string, PairsList> CryptoCurrencies { get; }
		Dictionary<string, Exchange> Exchanges { get; }
		DataCollector DataCollector { get; }
		Metrics Metrics { get; }
		Notification Notification { get; }
		Dictionary<string, object> Services { get; }
		List<string>? TentaclesPackages { get; }
		Trader Trader { get; }
		TraderSimulator TraderSimulator { get; }
		Trading Trading { get; }
		List<string> WatchedSymbols { get; }
		Dictionary<string, object> AdvancedClasses { get; }
		List<Type> Evaluator { get; set; }
	}
}