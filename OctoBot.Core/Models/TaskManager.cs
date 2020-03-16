using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Core
{
	/// <summary>
	/// """TaskManager class:
	/// - Create, manage and stop octobot tasks """
	/// </summary>
	internal class TaskManager
	{
		private OctoBot Octobot { get; set; }
		private object AsyncLoop { get; set; }
		public bool Ready { get; set; }
		private object Watcher { get; set; }
		private object MainTaskGroup { get; set; }
		private object CurrentLoopThread { get; set; }

		private ILoggingService loggingService { get; set; }

		public TaskManager(OctoBot octobot)
		{
			Octobot = octobot;

			// Logger
			loggingService = Application.Resolve<ILoggingService>();

			AsyncLoop = null;
			Ready = false;
			Watcher = null;
			MainTaskGroup = null;
			CurrentLoopThread = null;
		}

		public void InitAsyncLoop()
		{
			Debug.WriteLine(1);
		}
		async private void StartTasks(bool runInNewThread = false)
		{
			Debug.WriteLine(1);
		}
		private void JoinThreads()
		{
			Debug.WriteLine(1);
		}
		private void StopThreads()
		{
			Debug.WriteLine(1);
		}
		private void CreateNewAsyncioMainLoop()
		{
			Debug.WriteLine(1);
		}
		private void RunInMainAsyncioLoop(object coroutine)
		{
			Debug.WriteLine(1);
		}
	}
}