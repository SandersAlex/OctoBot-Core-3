using System;
using System.Diagnostics;
using OctoBot.AppServices;
using OctoBot.Evaluator.Social;

namespace OctoBot.Tentacles
{
	public class RedditForumEvaluator : ForumSocialEvaluator, IDispatcherAbstractClient
	{
		public RedditForumEvaluator()
		{
			Debug.WriteLine(1);
		}

		private void SetDispatcher(object dispatcher)
		{
			Debug.WriteLine(1);
		}
		private static void GetDispatcherClass()
		{
			Debug.WriteLine(1);
		}
		private void PrintEntry(object entry_text, object entry_note, string count = "")
		{
			Debug.WriteLine(1);
		}
		async private void ReceiveNotificationData(object data)
		{
			Debug.WriteLine(1);
		}
		private void GetEvalNote()
		{
			Debug.WriteLine(1);
		}
		private void GetSentiment(object entry)
		{
			Debug.WriteLine(1);
		}
		private void IsInterestedByThisNotification(object notification_description)
		{
			Debug.WriteLine(1);
		}
		private void GetConfigElements(object key)
		{
			Debug.WriteLine(1);
		}
		private void FormatConfig()
		{
			Debug.WriteLine(1);
		}
		private void Prepare()
		{
			Debug.WriteLine(1);
		}
		protected override void GetData()
		{
			Debug.WriteLine(1);
		}
		async protected override void EvalImpl()
		{
			Debug.WriteLine(1);
		}
		async protected override void StartTask()
		{
			Debug.WriteLine(1);
		}
	}
}