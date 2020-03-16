using System;
using System.Diagnostics;
using OctoBot.Evaluator;
using OctoBot.Evaluator.Social;

namespace OctoBot.Tentacles
{
	public class TwitterNewsEvaluator : NewsSocialEvaluator, IDispatcherAbstractClient
	{
		public TwitterNewsEvaluator()
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
		private void GetTwitterService()
		{
			Debug.WriteLine(1);
		}
		private void PrintTweet(object tweet_text, object tweet_url, object note, string count = "")
		{
			Debug.WriteLine(1);
		}
		async private void ReceiveNotificationData(object data)
		{
			Debug.WriteLine(1);
		}
		async private void CheckEvalNote(object data)
		{
			Debug.WriteLine(1);
		}
		private static void ComputeNotificationTimeToLive(object evaluation)
		{
			Debug.WriteLine(1);
		}
		private void GetTweetSentiment(object tweet, object tweet_text, bool is_a_quote = false)
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
