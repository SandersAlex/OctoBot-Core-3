using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Evaluator.Social
{
	public abstract class SocialEvaluator : AbstractEvaluator
	{
		public SocialEvaluator() : base()
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
		private void AddEvaluatorTaskManager(object evaluator_task)
		{
			Debug.WriteLine(1);
		}
		async private void NotifyEvaluatorTaskManagers(object notifier_name)
		{
			Debug.WriteLine(1);
		}
		private void LoadConfig()
		{
			Debug.WriteLine(1);
		}
		private void GetIsToBeIndependentlyTasked()
		{
			Debug.WriteLine(1);
		}
		private void GetIsSelfRefreshing()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// to implement in subclasses if config necessary
		/// required if is_to_be_independently_tasked = False --> provide evaluator refreshing time
		/// </summary>
		private void SetDefaultConfig()
		{
			Debug.WriteLine(1);
		}
		private void GetSocialConfig()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// is called just before start(), implement if necessary
		/// </summary>
		private void Prepare()
		{
			Debug.WriteLine(1);
		}
		protected override abstract void EvalImpl();
		/// <summary>
		/// get data needed to perform the eval
		/// example :
		/// def get_data(self):
		///    for follow in followers:
		///       self.data.append(twitter.API(XXXXX))
		/// </summary>
		protected abstract void GetData();
	}
	public abstract class StatsSocialEvaluator : SocialEvaluator
	{
		protected override abstract void EvalImpl();
		protected override abstract void GetData();
	}
	public abstract class ForumSocialEvaluator : SocialEvaluator
	{
		protected override abstract void EvalImpl();
		protected override abstract void GetData();
	}
	public abstract class NewsSocialEvaluator : SocialEvaluator
	{
		protected override abstract void EvalImpl();
		protected override abstract void GetData();
	}
}