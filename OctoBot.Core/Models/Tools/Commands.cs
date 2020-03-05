using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Config;
using OctoBot.Core;
using OctoBot.Tentacles.Manager;
using Serilog.Core;

namespace OctoBot.Tools
{
	public static class Commands
	{
		public static void DataCollector(object config, bool useCatch = true)
		{
			Debug.WriteLine(1);
		}
		public static void PackageManager(ITentacleManagerService tentacleManagerService, ICoreConfig config, IList<string> commands, bool useCatch = false, bool force = false, string defaultGitBranch = "")
		{
			if (defaultGitBranch == "") defaultGitBranch = TentaclesManagerVars.TENTACLES_DEFAULT_BRANCH;

			try
			{
				if (commands.Contains(ConfigVars.TENTACLES_FORCE_CONFIRM_PARAM) == true)
				{
					force = true;
					commands.Remove(ConfigVars.TENTACLES_FORCE_CONFIRM_PARAM);
				}

				var tentacleManager = tentacleManagerService.CreateTentacleManager(config);
				tentacleManager.ParseCommands(commands, force, defaultGitBranch);
			}
			catch (Exception exc)
			{
				if (useCatch == false) throw new Exception(exc.Message);
			}
		}
		public static void TentacleCreator(object config, object commands, bool useCatch = false)
		{
			Debug.WriteLine(1);
		}
		public static void ExchangeKeysEncrypter(bool useCatch = false)
		{
			Debug.WriteLine(1);
		}
		public static void StartStrategyOptimizer(object config, object commands)
		{
			Debug.WriteLine(1);
		}
		public static void SignalHandler()
		{
			Debug.WriteLine(1);
		}
		public static async void StartBot(object bot, object logger, bool useCatch = false)
		{
			Debug.WriteLine(1);
		}
		public static void StopBot(object bot)
		{
			Debug.WriteLine(1);
		}
		public static void RestartBot()
		{
			Debug.WriteLine(1);
		}
	}
}