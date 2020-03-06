using System;
using System.Diagnostics;
using OctoBot.Evaluator;

namespace OctoBot.Tentacles
{
	public class TrendAnalysis : AbstractUtil
	{
		private static void GetTrend(object data, object averages_to_use)
		{
			Debug.WriteLine(1);
		}
		private static void PeakHasBeenReachedAlready(object data, int neutral_val = 0)
		{
			Debug.WriteLine(1);
		}
		private static void MinHasJustBeenReached(object data, decimal acceptance_window = 0.8m, int delay= 1)
		{
			Debug.WriteLine(1);
		}
		private static void DetectDivergence(object data_frame, object indicator_data_frame)
		{
			Debug.WriteLine(1);
		}
		private static void GetEstimationOfMoveStateRelativelyToPreviousMovesLength(object mean_crossing_indexes, object current_trend, int pattern_move_size = 1, int double_size_patterns_count= 0)
		{
			Debug.WriteLine(1);
		}
		private static void GetThresholdChangeIndexes(object data, object threshold)
		{
			Debug.WriteLine(1);
		}
		private static void HaveJustCrossedOver(object list_1, object list_2)
		{
			Debug.WriteLine(1);
		}
	}
}
