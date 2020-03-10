using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Core
{
	/// <summary>
	/// """EvaluatorFactory class:
	/// - Create evaluators """
	/// </summary>
	internal class EvaluatorFactory
	{
		private OctoBot Octobot { get; set; }

		private ILoggingService loggingService { get; set; }

		private Dictionary<string, object> SymbolTasksManager { get; set; }
		private Dictionary<string, object> SymbolEvaluatorList { get; set; }
		private Dictionary<string, object> CryptoCurrencyEvaluatorList { get; set; }
		private List<object> DispatchersList { get; set; }
		private List<object> SocialEvalTasks { get; set; }
		private List<object> RealTimeEvalTasks { get; set; }

		public EvaluatorFactory(OctoBot octobot)
		{
			Octobot = octobot;

			// Logger
			loggingService = Application.Resolve<ILoggingService>();

			SymbolTasksManager = new Dictionary<string, object>();
			SymbolEvaluatorList = new Dictionary<string, object>();
			CryptoCurrencyEvaluatorList = new Dictionary<string, object>();
			DispatchersList = new List<object>();
			SocialEvalTasks = new List<object>();
			RealTimeEvalTasks = new List<object>();
		}

		private void Create()
		{
			Debug.WriteLine(1);
		}
		private void CreateDispatchers()
		{
			Debug.WriteLine(1);
		}
		private void EvaluationTasksCreation()
		{
			Debug.WriteLine(1);
		}
		private void CreateCryptoCurrencyEvaluatorTasks(object crypto_currency)
		{
			Debug.WriteLine(1);
		}
		private void CreateCryptoCurrencyEvaluator(object crypto_currency)
		{
			Debug.WriteLine(1);
		}
		private void CreateSymbolEvaluators(object exchange, object crypto_currency)
		{
			Debug.WriteLine(1);
		}
		private void CreateSymbolEvaluator(object symbol, object crypto_currency_evaluator)
		{
			Debug.WriteLine(1);
		}
		private void GetGlobalPriceUpdaterFromExchangeName(object exchange)
		{
			Debug.WriteLine(1);
		}
		private void CreateSymbolThreadsManagers(object exchange, object symbol_evaluator, object global_price_updater)
		{
			Debug.WriteLine(1);
		}
		private void CreateEvaluatorTaskManagersWithTimeFrame(object exchange, object symbol_evaluator, object global_price_updater, object real_time_ta_eval_list)
		{
			Debug.WriteLine(1);
		}
		private static void IsTimeFrameExistsInExchange(object exchange, object symbol_evaluator, object time_frame)
		{
			Debug.WriteLine(1);
		}
		private void CreateRealTimeTaList(object exchange, object symbol_evaluator)
		{
			Debug.WriteLine(1);
		}
		private void CreateRealTimeTaEvaluators(object exchange, object symbol_evaluator)
		{
			Debug.WriteLine(1);
		}
		private void CreateEvaluatorTaskManager(object time_frame, object global_price_updater, object symbol_evaluator, object exchange, object real_time_ta_eval_list)
		{
			Debug.WriteLine(1);
		}
		private void CheckRequiredEvaluators()
		{
			Debug.WriteLine(1);
		}
		private static void ClassIsInList(object class_list, object required_klass)
		{
			Debug.WriteLine(1);
		}
	}
}