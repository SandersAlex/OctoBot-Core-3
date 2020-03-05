using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.AppServices;

namespace OctoBot.Evaluator.RealTime
{
	public abstract class RealTimeEvaluator : AbstractEvaluator
	{
		public RealTimeEvaluator() : base()
		{
			Debug.WriteLine(1);
		}

		protected override void GetConfigTentacleType(object cls)
		{
			Debug.WriteLine(1);
		}
		private void Stop()
		{
			Debug.WriteLine(1);
		}
		private void LoadConfig()
		{
			Debug.WriteLine(1);
		}
		private void AddEvaluatorTaskManager(object evaluator_task)
		{
			Debug.WriteLine(1);
		}
		async private void NotifyEvaluatorTaskManagers(object notifier_name, bool force_TA_refresh = false)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// to implement in subclasses if config necessary
		/// </summary>
		private void SetDefaultConfig()
		{
			Debug.WriteLine(1);
		}
		protected abstract void RefreshData();
		protected abstract void ShouldEval();
		protected abstract void DefineRefreshTime();
		protected override abstract void EvalImpl();
		async protected override void StartTask()
		{
			Debug.WriteLine(1);
		}
	}
	public abstract class RealTimeExchangeEvaluator : RealTimeEvaluator
	{
		public RealTimeExchangeEvaluator()
		{
			Debug.WriteLine(1);
		}

		protected override abstract void RefreshData();
		protected override abstract void EvalImpl();
		private void ValidRefreshTime(object config_refresh_time)
		{
			Debug.WriteLine(1);
		}
		protected override void DefineRefreshTime()
		{
			Debug.WriteLine(1);
		}
		async private void GetDataFromExchange(object time_frame, object limit = null, bool return_list = false)
		{
			Debug.WriteLine(1);
		}
		async private void GetOrderBookFromExchange(object limit = null)
		{
			Debug.WriteLine(1);
		}
		async private void GetRecentTradesFromExchange(object limit = null)
		{
			Debug.WriteLine(1);
		}
		private static void CompareData(object new_data, object old_data)
		{
			Debug.WriteLine(1);
		}
		private void SetDefaultConfig()
		{
			Debug.WriteLine(1);
		}
	}
	public abstract class RealTimeSignalEvaluator : RealTimeEvaluator, IDispatcherAbstractClient
	{
		public RealTimeSignalEvaluator()
		{
			Debug.WriteLine(1);
		}

		protected override void RefreshData()
		{
			Debug.WriteLine(1);
		}
		protected override void ShouldEval()
		{
			Debug.WriteLine(1);
		}
		protected override void DefineRefreshTime()
		{
			Debug.WriteLine(1);
		}
		protected override abstract void EvalImpl();
		protected abstract void ReceiveNotificationData(object data);
		protected abstract void GetDispatcherClass();
		protected abstract void IsInterestedByThisNotification(object notification_description);
	}
}