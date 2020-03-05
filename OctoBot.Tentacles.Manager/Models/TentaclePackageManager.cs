using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OctoBot.Core;
using OctoBot.Utils;
using OctoBot.Evaluator.RealTime;
using OctoBot.Evaluator.Social;
using OctoBot.Evaluator.Strategies;
using OctoBot.Evaluator.TA;
using Serilog.Core;

namespace OctoBot.Tentacles.Manager
{
	public class TentaclePackageManager
	{
		private ICoreConfig Config { get; set; }
		private TentacleManager TentacleManager { get; set; }
		private List<string> JustProcessedModules { get; set; }
		private Dictionary<string, object> InstalledModules { get; set; }
		private int? MaxSteps { get; set; }
		private int CurrentStep { get; set; }

		private readonly ILoggingService loggingService;

		public TentaclePackageManager(ICoreConfig config, TentacleManager tentacleManager)
		{
			Config = config;
			TentacleManager = tentacleManager;
			JustProcessedModules = new List<string>();
			InstalledModules = new Dictionary<string, object>();
			MaxSteps = null;
			CurrentStep = 1;

			loggingService = Application.Resolve<ILoggingService>();
		}

		private bool ProcessActionOnModule(TentaclesManagerVars.TentacleManagerActions action, TypeEnum moduleType, string moduleSubtype, string moduleVersion, string moduleFileContent, Dictionary<string, string> moduleTestFiles, string targetFolder, string moduleName)
		{
			var lst = TentaclesManagerVars.TENTACLE_TYPES.Where(x=>x.ContainsKey(moduleSubtype)).Select(x=>x).ToList();

			if (lst.Count > 0 && (moduleSubtype != "" || lst.Count > 0))
			{
				bool didSomething = false;

				// Update module file
				string moduleFileDir = TentacleUtil.CreatePathFromType(moduleType, moduleSubtype, targetFolder);
				string moduleFilePath = $"{moduleFileDir}/{moduleName}.py";

				// Write the new file in locations
				if (action == TentaclesManagerVars.TentacleManagerActions.INSTALL || action == TentaclesManagerVars.TentacleManagerActions.UPDATE)
				{
					// Install package in evaluator

					Debug.WriteLine(1);

					didSomething = true;
				}
				// Remove package line from init file
				else if (action == TentaclesManagerVars.TentacleManagerActions.UNINSTALL)
				{
					Debug.WriteLine(1);

					didSomething = true;
				}

				// Update local __init__
				// string linesInInit = $"\"\"try: check_tentacle(PATH, '{moduleName}') from.{ moduleName} import* except Exception as e: LOGGER.error(f'Error when loading {moduleName}: {{e}}') \"\"";
				// string initFile = $"{TENTACLES_PATH}/{TENTACLE_TYPES[module_type]}/{TENTACLE_TYPES[module_subtype]}/" + $"{target_folder}/{PYTHON_INIT_FILE}";

				// self.update_init_file(action, init_file, lines_in_init)

				// Update module test files
				string testFileDir = TentacleUtil.CreatePathFromType(moduleType, moduleSubtype, targetFolder, true);
				foreach (var elem in moduleTestFiles)
				{
					Debug.WriteLine(1);
				}

				if (action == TentaclesManagerVars.TentacleManagerActions.INSTALL)
				{
					loggingService.Info($"{FormatCurrentStep()}{moduleName} {moduleVersion} " + $"успешно установлен в: {moduleFileDir}");
				}
				else if (action == TentaclesManagerVars.TentacleManagerActions.UNINSTALL)
				{
					if (didSomething == true) loggingService.Info($"{FormatCurrentStep()}{moduleName} {moduleVersion} " + $"успешно удален (файл: {moduleFileDir})");
				}
				else if (action == TentaclesManagerVars.TentacleManagerActions.UPDATE)
				{
					loggingService.Info($"{FormatCurrentStep()}{moduleName} успешно обновлен до версии " + $"{moduleVersion} в: {moduleFileDir}");
				}

				JustProcessedModules.Add(TentacleUtil.GetFullModuleIdentifier(moduleName, moduleVersion));

				return didSomething;
			}
			else
			{
				throw new Exception("Не нйадены типы Tentacle");
			}
		}
		private void ProcessModule(TentaclesManagerVars.TentacleManagerActions action, Dictionary<string, TentacleModule> package, string moduleName, Uri packageLocalisation, bool isUrl, string targetFolder, string packageName)
		{
			Dictionary<string, object> parsedModule = TentacleUtil.ParseModuleHeader(package[moduleName]);
			var moduleType = (TypeEnum)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_TYPE];
			var moduleSubtype = (string)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_SUBTYPE];
			var moduleTests = (List<string>)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_TESTS];
			string moduleFileContent = "";
			var moduleDev = (bool)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_DEV];
			Dictionary<string, string> moduleTestFiles = new Dictionary<string, string>();
			if (moduleTests != null) /*foreach (var test in moduleTests)*/ moduleTestFiles.Add("test", "");

			if (TentacleUtil.InstallOnDevelopment(Config, moduleDev) == true)
			{
				if (action == TentaclesManagerVars.TentacleManagerActions.INSTALL || action == TentaclesManagerVars.TentacleManagerActions.UPDATE)
				{
					var locationStr = TentacleUtil.CreateLocalizationFromType(packageLocalisation, moduleType, moduleSubtype, moduleName);

					string moduleLoc = $"{locationStr}.py";

					if (isUrl == true)
					{
						Debug.WriteLine(1);
						//moduleFileContent = TentaclePackageUtil.GetPackageFileContentFromUrl(moduleLoc);
					}
					else
					{
						Debug.WriteLine(1);
					}

					moduleFileContent = TentaclePackageUtil.AddPackageName(moduleFileContent, packageName);

					if (moduleTestFiles.Count > 0)
					{
						foreach (var test in moduleTests)
						{
							locationStr = TentacleUtil.CreateLocalizationFromType(packageLocalisation, moduleType, moduleSubtype, test, true);

							string testLoc = $"{locationStr}.py";

							if (isUrl == true)
							{
								Debug.WriteLine(1);
							}
							else
							{
								Debug.WriteLine(1);
							}
						}
					}
				}

				if (ProcessActionOnModule(action, moduleType, moduleSubtype, (string)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_VERSION], moduleFileContent, moduleTestFiles, targetFolder, moduleName) == true)
				{
					// manage module config
					TryActionOnConfigOrResources(action, parsedModule, moduleName, isUrl, packageLocalisation);
				}

				if (action == TentaclesManagerVars.TentacleManagerActions.INSTALL || action == TentaclesManagerVars.TentacleManagerActions.UPDATE)
				{
					TryActionOnRequirements(action, parsedModule, packageName);
				}
			}
			else if (action == TentaclesManagerVars.TentacleManagerActions.INSTALL || action == TentaclesManagerVars.TentacleManagerActions.UPDATE)
			{
				loggingService.Info($"{moduleName} в данный момент находится в разработке, он не будет установлен (чтобы в любом случае его установить, добавьте \"DEV-MODE\": true в вашем config.json)");
			}
		}
		private bool ShouldDoSomething(TentaclesManagerVars.TentacleManagerActions action, string moduleName, string moduleVersion, bool needThisExactVersion = false, object requiring = null, object parsedModule = null, object package = null)
		{
			if (action == TentaclesManagerVars.TentacleManagerActions.UPDATE)
			{
				Debug.WriteLine(1);

				return false;
			}
			else
			{
				return true;
			}
		}
		public void TryActionOnTentaclesPackage(TentaclesManagerVars.TentacleManagerActions action, TentaclesListJson package, string targetFolder)
		{
			var packageDescription = package.PackageDescription;
			var packageLocalisation = new Uri(packageDescription.Localisation.ToString().Replace(TentaclesManagerVars.GITHUB_BASE_URL, TentaclesManagerVars.GITHUB_RAW_CONTENT_URL));
			var isUrl = packageDescription.IsUrl;
			var packageName = packageDescription.Name;

			foreach (var tentacleModule in package.ListPuneHedgehog)
			{
				var tentacleModuleName = tentacleModule.Key;
				TentacleModule tentacleModuleContent = tentacleModule.Value;

				try
				{
					if (HasJustProcessedModule(tentacleModuleName, tentacleModuleContent.Version) == false && ShouldDoSomething(action, tentacleModuleName, tentacleModuleContent.Version, package: tentacleModuleContent) == true)
					{
						ProcessModule(action, package.ListPuneHedgehog, tentacleModuleName, packageLocalisation, isUrl, targetFolder, packageName);
					}
				}
				catch (Exception exc)
				{
					Debug.WriteLine(1);
				}

				IncCurrentStep();
			}
		}
		private void TryActionOnRequirements(TentaclesManagerVars.TentacleManagerActions action, Dictionary<string, object> parsedModule, string packageName)
		{
			bool success = true;
			string moduleName = (string)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_NAME];
			List<string> appliedModules = new List<string>() { moduleName };

			if (parsedModule[TentaclesManagerVars.TENTACLE_MODULE_REQUIREMENTS] != null)
			{
				foreach (var requirementData in (List<Dictionary<string, string>>)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_REQUIREMENTS])
				{
					if (success == true)
					{
						string requirementModuleName = requirementData[TentaclesManagerVars.TENTACLE_MODULE_NAME];
						string requirementModuleVersion = requirementData[TentaclesManagerVars.TENTACLE_MODULE_VERSION];

						if (HasJustProcessedModule(requirementModuleName, requirementModuleVersion) == false && ShouldDoSomething(action, requirementModuleName, requirementModuleVersion, true, moduleName, parsedModule: parsedModule) == true)
						{
							try
							{
								(Dictionary<string, TentacleModule> reqPackage, PackageDescription t1, Uri localisation, bool? isUrl, string destination, string t2) = TentacleManager.GetPackageInLists(requirementModuleName, requirementModuleVersion);

								if (reqPackage != null)
								{
									ProcessModule(action, reqPackage, requirementModuleName, localisation, (bool)isUrl, destination, packageName);
									appliedModules.Add(requirementModuleName);
								}
								else throw new Exception($"Требования для модуля '" + $"{requirementData[TentaclesManagerVars.TENTACLE_MODULE_REQUIREMENT_WITH_VERSION]}' " + $"не найдены в списке пакетов");
							}
							catch (Exception exc)
							{
								string error = $"Ошибка обработки требований модуля tentacle '{requirementModuleName}' " + $"из модуля {moduleName} ({exc.Message})";
								if (action == TentaclesManagerVars.TentacleManagerActions.INSTALL) loggingService.Error($"Установка {error}");
								else if (action == TentaclesManagerVars.TentacleManagerActions.UNINSTALL) loggingService.Error($"Удаление {error}");
								else if (action == TentaclesManagerVars.TentacleManagerActions.UPDATE) loggingService.Error($"Обновление {error}");
								success = false;
							}
						}
					}
				}

				// failed to install requirements
				if (success == false)
				{
					if (action == TentaclesManagerVars.TentacleManagerActions.UPDATE)
					{
						Debug.WriteLine(1);
					}
					else if (action == TentaclesManagerVars.TentacleManagerActions.INSTALL)
					{
						Debug.WriteLine(1);
					}
				}
			}
		}
		private void TryActionOnConfigOrResources(TentaclesManagerVars.TentacleManagerActions action, Dictionary<string, object> parsedModule, string moduleName, bool isUrl, Uri packageLocalisation)
		{
			string fileDir = TentacleUtil.CreatePathFromType((TypeEnum)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_TYPE], (string)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_SUBTYPE], "");

			if (parsedModule[TentaclesManagerVars.TENTACLE_MODULE_CONFIG_FILES] != null)
			{
				foreach (string configFile in (List<string>)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_CONFIG_FILES])
				{
					string configFilePath = $"{fileDir}{TentaclesManagerVars.EVALUATOR_CONFIG_FOLDER}/{configFile}";
					string defaultConfigFilePath = $"{fileDir}{TentaclesManagerVars.EVALUATOR_CONFIG_FOLDER}/{TentaclesManagerVars.EVALUATOR_DEFAULT_FOLDER}/{configFile}";

					TryActionOnConfigOrResourceFile(action, moduleName, packageLocalisation, isUrl, parsedModule, configFile, configFilePath, defaultFilePath: defaultConfigFilePath);
				}
			}

			if (parsedModule[TentaclesManagerVars.TENTACLE_MODULE_CONFIG_SCHEMA_FILES] != null)
			{
				foreach (string configSchemaFile in (List<string>)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_CONFIG_SCHEMA_FILES])
				{
					string configSchemaFilePath = $"{fileDir}{TentaclesManagerVars.EVALUATOR_CONFIG_FOLDER}/{configSchemaFile}";
					string defaultConfigSchemaFilePath = $"{fileDir}{TentaclesManagerVars.EVALUATOR_CONFIG_FOLDER}/{TentaclesManagerVars.EVALUATOR_DEFAULT_FOLDER}/{configSchemaFile}";

					TryActionOnConfigOrResourceFile(action, moduleName, packageLocalisation, isUrl, parsedModule, configSchemaFile, configSchemaFilePath, defaultFilePath: defaultConfigSchemaFilePath, forceRefresh: true);
				}
			}

			if (parsedModule[TentaclesManagerVars.TENTACLE_MODULE_RESOURCE_FILES] != null)
			{
				Debug.WriteLine(1);
			}
		}
		private void TryActionOnConfigOrResourceFile(TentaclesManagerVars.TentacleManagerActions action, string moduleName, Uri packageLocalisation, bool isUrl, Dictionary<string, object> parsedModule, string file, string filePath, string defaultFilePath = "", bool readAsBytes = false, bool forceRefresh = false)
		{
			if (action == TentaclesManagerVars.TentacleManagerActions.INSTALL || action == TentaclesManagerVars.TentacleManagerActions.UPDATE)
			{
				try
				{
					// get config file content from localization
					string moduleLoc = TentacleUtil.CreateLocalizationFromType(packageLocalisation, (TypeEnum)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_TYPE], (string)parsedModule[TentaclesManagerVars.TENTACLE_MODULE_SUBTYPE], file);

					string configFileContent = "";

					if (isUrl == true)
					{
						configFileContent = TentaclePackageUtil.GetPackageFileContentFromUrl(moduleLoc, asBytes: readAsBytes);
					}
					else
					{
						configFileContent = FileUtilities.GetFileContents(moduleLoc);
					}

					if (forceRefresh == true)
					{
						FileUtilities.SaveFileContents(filePath, configFileContent);
					}
					else
					{
						// install local file content
						if (TentaclePackageUtil.ShouldRecreateConfigFile(filePath, configFileContent) == true)
						{
							FileUtilities.SaveFileContents(filePath, configFileContent);
						}
						else loggingService.Info($"Файл конфигурации / ресурсов {file} для модуля {moduleName} был проигнорирован " + $"чтобы сохранить текущую конфигурацию. Файл конфигурации по умолчанию " + $"был обновлен в: {defaultFilePath}.");
					}

					// copy into default
					if (defaultFilePath != "")
					{
						FileUtilities.SaveFileContents(defaultFilePath, configFileContent);
					}
				}
				catch (Exception exc)
				{
					throw new Exception($"Ошибка при установке файла конфигурации / ресурсов: {exc.Message}");
				}
			}
			else if (action == TentaclesManagerVars.TentacleManagerActions.UNINSTALL)
			{
				Debug.WriteLine(1);
			}
		}
		private bool HasJustProcessedModule(string moduleName, string moduleVersion)
		{
			return TentacleUtil.IsModuleInList(moduleName, moduleVersion, JustProcessedModules);
		}
		private static void GetInstalledModules()
		{
			Debug.WriteLine(1);
		}
		private string FormatCurrentStep()
		{
			return MaxSteps != null ? $"{CurrentStep}/{MaxSteps}: " : "";
		}
		public void SetMaxSteps(int maxSteps)
		{
			MaxSteps = maxSteps;
		}
		private void SetInstalledModules(object installedModules)
		{
			Debug.WriteLine(1);
		}
		private void IncCurrentStep()
		{
			CurrentStep += 1;
		}
		private static void UpdateInitFile(object action, object initFile, object linesInInit)
		{
			Debug.WriteLine(1);
		}
		private static void CreateInitFile(object initFile)
		{
			Debug.WriteLine(1);
		}
		private static void LogConfigFileUpdateException(string exception)
		{
			Debug.WriteLine(1);
		}
		public void UpdateEvaluatorConfigFile(string evaluatorConfigFile = "")
		{
			if (evaluatorConfigFile == "") evaluatorConfigFile = TentaclesManagerVars.CONFIG_EVALUATOR_FILE_PATH;

			try
			{
				loggingService.Info($"Обновляю {evaluatorConfigFile} используя новые данные...");

				List<Type> evaluatorsInConfig = new List<Type>() { typeof(TAEvaluator), typeof(SocialEvaluator), typeof(RealTimeEvaluator), typeof(StrategiesEvaluator) };

				TentaclePackageUtil.UpdateConfigFile(evaluatorConfigFile, TentaclesManagerVars.CONFIG_DEFAULT_EVALUATOR_FILE, evaluatorsInConfig);
			}
			catch (Exception exc)
			{
				LogConfigFileUpdateException(exc.Message);
			}

			Debug.WriteLine(1);
		}
		public void UpdateTradingConfigFile(object tradingConfigFile = null)
		{
			//if (tradingConfigFile == null) tradingConfigFile = CONFIG_TRADING_FILE_PATH;

			Debug.WriteLine(1);
		}
	}
}