using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Core;
using OctoBot.TentaclesManagement;

namespace OctoBot.Evaluator
{
	public abstract class AbstractEvaluator : AbstractTentacle, IAbstractEvaluator
	{
		public AbstractEvaluator()
		{
			Debug.WriteLine(1);
		}

		protected override void GetTentacleFolder(object cls)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Override this method when self.eval_note is other than : START_PENDING_EVAL_NOTE or float[-1:1]
		/// </summary>
		private void GetEvalType()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Used to provide the global config
		/// </summary>
		/// <param name="config"></param>
		private void SetConfig(object config)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Symbol is the cryptocurrency symbol
		/// </summary>
		/// <param name="symbol"></param>
		private void SetSymbol(object symbol)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Active tells if this evalautor is currently activated (an evaluator can be paused)
		/// </summary>
		/// <param name="is_active"></param>
		private void SetIsActive(object is_active)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// history time represents the period of time of the indicator
		/// </summary>
		/// <param name="history_time"></param>
		private void SetHistoryTime(object history_time)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Eval note will be set by the eval_impl at each call
		/// </summary>
		private void GetEvalNote()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// set to true if start_task has to be called to start evaluator
		/// </summary>
		/// <param name="value"></param>
		private void SetIsToBeStartedAsTask(object value)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Pertinence of indicator will be used with the eval_note to provide a relevancy
		/// </summary>
		private void GetPertinence()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// If this indicator is enabled
		/// </summary>
		private void GetIsEnabled()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Active tells if this evaluator is currently activated (an evaluator can be paused)
		/// </summary>
		private void GetIsActive()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Return the evaluator symbol
		/// </summary>
		private void GetSymbol()
		{
			Debug.WriteLine(1);
		}
		private void GetIsToBeStartedAsTask()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// generic eval that will call the indicator eval_impl()
		/// </summary>
		async private void Eval()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// eval new data
		/// Notify if new data is relevant
		/// example :
		/// async def eval_impl(self):
		///    for post in post_selected
		///       note = sentiment_evaluator(post.text)
		/// if (note > 10 || note < 0):
		///    self.need_to_notify = True
		///  self.eval_note += note
		/// </summary>
		protected abstract void EvalImpl();
		/// <summary>
		/// reset temporary parameters to enable fresh start
		/// </summary>
		private void Reset()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// explore up to the 2nd degree parent
		/// </summary>
		/// <param name="cls"></param>
		/// <param name="klass"></param>
		private void HasClassInParents(object cls, object klass)
		{
			Debug.WriteLine(1);
		}
		private void GetParentEvaluatorClasses(object cls, object higher_parent_class_limit = null)
		{
			Debug.WriteLine(1);
		}
		private void SetEvalNote(object new_eval_note)
		{
			Debug.WriteLine(1);
		}
		public bool IsEnabled(Type cls, ICoreConfig config, bool defaultObject)
		{
			if (config.Evaluator.Count > 0)
			{

			}

			Debug.WriteLine(1);

			return false;
		}
		private void SaveEvaluationExpirationTime(object eval_note_time_to_live, object eval_note_changed_time = null)
		{
			Debug.WriteLine(1);
		}
		private void EvalNoteChanged()
		{
			Debug.WriteLine(1);
		}
		private void EnsureEvalNoteIsNotExpired()
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// async task that can be use get_data to provide real time data
		/// will ONLY be called if self.is_to_be_started_as_task is set to True
		/// example :
		/// def start_task(self):
		///    while True:
		///       self.get_data()                           --> pull the new data
		///       self.eval()                               --> create a notification if necessary
		///       await asyncio.sleep(own_time * MINUTE_TO_SECONDS)  --> use its own refresh time
		/// </summary>
		protected abstract void StartTask();
	}
}