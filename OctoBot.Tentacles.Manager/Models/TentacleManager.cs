using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.Core;
using Serilog.Core;

namespace OctoBot.Tentacles.Manager
{
	public class TentacleManager : ITentacleManager
	{
		private ICoreConfig Config { get; set; }
		private TentaclePackageManager TentaclePackageManager { get; set; }
		private TentaclesListJson DefaultPackage { get; set; }
		private List<object> AdvancedPackageList { get; set; }
		private bool ForceActions { get; set; }
		private string GitBranch { get; set; }

		private readonly ILoggingService loggingService;

		public TentacleManager(ICoreConfig config)
		{
			Config = config;
			TentaclePackageManager = new TentaclePackageManager(config, this);
			DefaultPackage = null;
			AdvancedPackageList = new List<object>();
			ForceActions = false;
			GitBranch = TentaclesManagerVars.TENTACLES_DEFAULT_BRANCH;

			loggingService = Application.Resolve<ILoggingService>();
		}

		private void InstallTentaclePackage(object packagePathOrUrl, bool force = false)
		{
			Debug.WriteLine(1);
		}
		private void UpdateGitBranch(IList<string> commands, string defaultGitBranch)
		{
			string branchCmd = "branch";
			string equalsSeparator = "=";
			string branchEqualsCmd = $"{branchCmd}{equalsSeparator}";

			// check if specific branch is specified in commands
			// if found, set self.git_branch and remove info from commands
			if (commands.Contains(branchCmd) == true && commands.Count - 1 > commands.IndexOf(branchCmd))
			{
				Debug.WriteLine(1);
			}
			else if (commands.Contains(branchCmd) == true)
			{
				Debug.WriteLine(1);
			}
			else
			{
				// otherwise use default
				GitBranch = defaultGitBranch;
			}
		}
		public void ParseCommands(IList<string> commands, bool force = false, string defaultGitBranch = "")
		{
			if (defaultGitBranch == "") defaultGitBranch = TentaclesManagerVars.TENTACLES_DEFAULT_BRANCH;

			UpdateGitBranch(commands, defaultGitBranch);
			UpdateList();

			List<string> helpArray = new List<string>() { "help", "h", "-h", "--help" };

			if (commands.Count > 0)
			{
				if (commands[0] == "install")
				{
					if (commands[1] == "all")
					{
						InstallParser(commands, true, force);
					}
					else
					{
						commands.RemoveAt(0);
						InstallParser(commands, false, force);
					}
				}
				else if (commands[0] == "update")
				{
					Debug.WriteLine(1);
				}
				else if (commands[0] == "uninstall")
				{
					Debug.WriteLine(1);
				}
				else if (commands[0] == "reset_tentacles")
				{
					Debug.WriteLine(1);
				}
				else if (helpArray.Contains(commands[0]) == true)
				{
					Debug.WriteLine(1);
				}
				else
				{
					Debug.WriteLine(1);
				}
			}
			else
			{
				Debug.WriteLine(1);
			}
		}
		private int InstallParser(IList<string> commands, bool commandAll = false, bool force = false)
		{
			bool shouldInstall = true;

			// first ensure the current tentacles architecture is setup correctly
			if (TentacleUtil.CreateMissingTentaclesArch() == true && force == false)
			{
				Debug.WriteLine(1);
			}

			int nbActions = 0;

			if (shouldInstall == true)
			{
				// then process installations
				if (commandAll == true)
				{
					TentaclePackageManager.SetMaxSteps(GetPackageCount());
					TentaclePackageManager.TryActionOnTentaclesPackage(TentaclesManagerVars.TentacleManagerActions.INSTALL, DefaultPackage, TentaclesManagerVars.EVALUATOR_DEFAULT_FOLDER);

					foreach (var package in AdvancedPackageList)
					{
						TentaclePackageManager.TryActionOnTentaclesPackage(TentaclesManagerVars.TentacleManagerActions.INSTALL, (TentaclesListJson)package, TentaclesManagerVars.EVALUATOR_ADVANCED_FOLDER);
					}

					nbActions = GetPackageCount();
				}
				else
				{
					Debug.WriteLine(1);
				}

				TentaclePackageManager.UpdateEvaluatorConfigFile();
				TentaclePackageManager.UpdateTradingConfigFile();

				return nbActions;
			}
			else return 0;
		}
		private void UpdateParser(object commands, bool commandAll = false)
		{
			Debug.WriteLine(1);
		}
		private void UninstallParser(object commands, bool commandAll = false)
		{
			Debug.WriteLine(1);
		}
		private void ResetTentacles()
		{
			Debug.WriteLine(1);
		}
		private void UpdateList()
		{
			string defaultPackageListUrl = TentaclePackageUtil.GetOctobotTentaclePublicRepo(gitBranch: GitBranch);

			DefaultPackage = TentaclePackageUtil.GetPackageDescription(defaultPackageListUrl, gitBranch: GitBranch);

			if (Config.TentaclesPackages != null)
			{
				foreach (var package in Config.TentaclesPackages)
				{
					Debug.WriteLine(1);
				}
			}
		}
		public (Dictionary<string, TentacleModule>, PackageDescription, Uri, bool?, string, string) GetPackageInLists(string componentName, string componentVersion = "")
		{
			if (TentacleUtil.HasRequiredPackage(DefaultPackage, componentName, componentVersion) == true)
			{
				var packageDescription = DefaultPackage.PackageDescription;
				var packageLocalisation = packageDescription.Localisation;
				var isUrl = packageDescription.IsUrl;
				var packageName = packageDescription.Name;

				return (DefaultPackage.ListPuneHedgehog, packageDescription, packageLocalisation, isUrl, TentaclesManagerVars.EVALUATOR_DEFAULT_FOLDER, packageName);
			}
			else
			{
				foreach (var advancedPackage in AdvancedPackageList)
				{
					if (TentacleUtil.HasRequiredPackage((TentaclesListJson)advancedPackage, componentName, componentVersion) == true)
					{
						var packageDescription = ((TentaclesListJson)advancedPackage).PackageDescription;
						var packageLocalisation = packageDescription.Localisation;
						var isUrl = packageDescription.IsUrl;
						var packageName = packageDescription.Name;

						return (((TentaclesListJson)advancedPackage).ListPuneHedgehog, packageDescription, packageLocalisation, isUrl, TentaclesManagerVars.EVALUATOR_DEFAULT_FOLDER, packageName);
					}
				}
			}

			return (null, null, null, null, null, null);
		}
		private void ConfirmAction(object action)
		{
			Debug.WriteLine(1);
		}
		private void SetForceActions(object forceActions)
		{
			Debug.WriteLine(1);
		}
		private int GetPackageCount()
		{
			int count = DefaultPackage.ListPuneHedgehog.Count;

			foreach (var advancedPackage in AdvancedPackageList)
			{
				Debug.WriteLine(1);
			}

			// remove 1 for tentacle description for each tentacles package
			return count - 1 * (1 + AdvancedPackageList.Count) + 1;
		}
	}
}