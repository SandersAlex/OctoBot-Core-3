using System;
using System.Diagnostics;
using OctoBot.Evaluator.RealTime;

namespace OctoBot.Tentacles
{
	public class TelegramSignalEvaluator : RealTimeSignalEvaluator
	{
		public TelegramSignalEvaluator()
		{
			Debug.WriteLine(1);
		}

		private void SetDispatcher(object dispatcher)
		{
			Debug.WriteLine(1);
		}
		async protected override void ReceiveNotificationData(object data)
		{
			Debug.WriteLine(1);
		}
		protected override void GetDispatcherClass()
		{
			Debug.WriteLine(1);
		}
		protected override void IsInterestedByThisNotification(object notification_description)
		{
			Debug.WriteLine(1);
		}
		private void AnalyseNotification(object notification)
		{
			Debug.WriteLine(1);
		}
		async protected override void EvalImpl()
		{
			throw new NotImplementedException();
		}
	}
}