using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using OctoBot.Core;
using OctoBot.Evaluator.Strategies;
using OctoBot.TentaclesManagement;

namespace OctoBot.Evaluator
{
	public class EvaluatorCreator
	{
		private void GetName(object cls)
		{
			Debug.WriteLine(1);
		}
		private static void GetLogger()
		{
			Debug.WriteLine(1);
		}
		private static void CreateTaEvalList(object evaluator, object relevant_evaluators)
		{
			Debug.WriteLine(1);
		}
		private static void CreateSocialEval(object config, object symbol, object dispatchers_list, object relevant_evaluators)
		{
			Debug.WriteLine(1);
		}
		private static void InstantiateRealTimeEvaluator(object real_time_eval_class, object exchange, object symbol)
		{
			Debug.WriteLine(1);
		}
		private static void CreateRealTimeTaEvals(object config, object exchange_inst, object symbol, object relevant_evaluators, object dispatchers_list)
		{
			Debug.WriteLine(1);
		}
		private static void CreateSocialNotTaskedList(object social_eval_list)
		{
			Debug.WriteLine(1);
		}
		private static void CreateStrategiesEvalList(object config)
		{
			Debug.WriteLine(1);
		}
		public static void InitTimeFramesFromStrategies(ICoreConfig config)
		{
			object timeFrameList = null;

			var lst = AdvancedManager.CreateAdvancedEvaluatorTypesList(typeof(StrategiesEvaluator), config);

			foreach (Type strategiesEvalClass in lst)
			{
				var instance = (IAbstractEvaluator)Activator.CreateInstance(strategiesEvalClass);

				if (instance.IsEnabled(strategiesEvalClass, config, false) == true)
				{

				}

				Debug.WriteLine(1);
			}

			Debug.WriteLine(1);
		}
		private static void GetRelevantEvaluatorsFromStrategies(object config)
		{
			Debug.WriteLine(1);
		}
		private static void IsRelevantEvaluator(object evaluator_instance, object relevant_evaluators)
		{
			Debug.WriteLine(1);
		}
		private static void GetRelevantTAsForStrategy(object strategy, object config)
		{
			Debug.WriteLine(1);
		}
	}
}