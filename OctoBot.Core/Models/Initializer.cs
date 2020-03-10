using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Core
{
	/// <summary>
	///  """Initializer class:
	///  - Initialize services, constants and tools """
	/// </summary>
	internal class Initializer
	{
		private OctoBot Octobot { get; set; }
		private object PerformanceAnalyser { get; set; }
		private object TimeFrames { get; set; }
		private List<object> RelevantEvaluators { get; set; }

		private ILoggingService loggingService { get; set; }

		public Initializer(OctoBot octobot)
		{
			Octobot = octobot;

			// Logger
			loggingService = Application.Resolve<ILoggingService>();

			PerformanceAnalyser = null;
			TimeFrames = null;
			RelevantEvaluators = new List<object>();
		}

		async private void Create()
		{
			Debug.WriteLine(1);
		}
		private void ManageAdvancedClasses()
		{
			Debug.WriteLine(1);
		}
		private void InitRelevantEvaluators()
		{
			Debug.WriteLine(1);
		}
		private void CreatePerformanceAnalyser()
		{
			Debug.WriteLine(1);
		}
		private void CreateNotifier()
		{
			Debug.WriteLine(1);
		}
		private void InitTimeFrames()
		{
			Debug.WriteLine(1);
		}
		async private void CreateServices()
		{
			Debug.WriteLine(1);
		}
		private void InitMetrics()
		{
			Debug.WriteLine(1);
		}
	}
}