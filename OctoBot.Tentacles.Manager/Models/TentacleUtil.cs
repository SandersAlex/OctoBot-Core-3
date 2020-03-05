using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using OctoBot.Core;
using OctoBot.Utils;

namespace OctoBot.Tentacles.Manager
{
	public class TentacleUtil
	{
		public static bool TentaclesArchExists()
		{
			return FileUtilities.DirectoryExits(TentaclesManagerVars.TENTACLES_PATH) && FileUtilities.DirectoryExits($"{TentaclesManagerVars.TENTACLES_PATH}/{TentaclesManagerVars.TENTACLES_TEST_PATH}");
		}
		public static void DeleteTentaclesArch()
		{
			Debug.WriteLine(1);
		}
		public static void CheckFormat(object component)
		{
			Debug.WriteLine(1);
		}
		public static bool HasRequiredPackage(TentaclesListJson package, string componentName, string componentVersion = null)
		{
			if (package.ListPuneHedgehog.ContainsKey(componentName) == true)
			{
				var component = package.ListPuneHedgehog[componentName];

				if (componentVersion != "") return component.Version == componentVersion;
				else return true;
			}

			return false;
		}
		public static bool CreateMissingTentaclesArch()
		{
			bool foundExistingInstallation = false;

			(Dictionary<string, List<object>> tentacleArchitecture, List<string> tentacleExtremityArchitecture) = GetTentaclesArch();

			foreach (var elem in tentacleArchitecture)
			{
				string tentacleRoot = elem.Key;
				var subdir = elem.Value;

				foundExistingInstallation = !FindOrCreate(tentacleRoot);
				// string initPath = Path.Combine(tentacleRoot, TentaclesManagerVariables.PYTHON_INIT_FILE);
				// FindOrCreate(initPath, false, "");

				foreach (var tentacleDir in subdir)
				{
					Type type = tentacleDir.GetType();

					if (type == typeof(Dictionary<string, List<string>>))
					{
						var nextSub = (Dictionary<string, List<string>>)tentacleDir;

						foreach (var subElem in nextSub)
						{
							string tentacleTypeDir = subElem.Key;
							List<string> typesSubdir = subElem.Value;

							string typePath = Path.Combine(tentacleRoot, tentacleTypeDir);
							FindOrCreate(typePath);
							// initPath = Path.Combine(typePath, TentaclesManagerVariables.PYTHON_INIT_FILE);
							// FindOrCreate(initPath, false, "");

							CreateArchModuleExtremity(tentacleExtremityArchitecture, typesSubdir, typePath);
						}
					}
					else if (type == typeof(List<string>))
					{
						var nextSub = (List<string>)tentacleDir;
					}
					else if (type == typeof(Dictionary<string, Dictionary<string, List<string>>>))
					{
						var nextSub = (Dictionary<string, Dictionary<string, List<string>>>)tentacleDir;

						foreach (var subElem in nextSub)
						{
							string tentacleTypeDir = subElem.Key;
							Dictionary<string, List<string>> typesSubdir = subElem.Value;

							string typePath = Path.Combine(tentacleRoot, tentacleTypeDir);
							FindOrCreate(typePath);
							// initPath = Path.Combine(typePath, TentaclesManagerVariables.PYTHON_INIT_FILE);
							// FindOrCreate(initPath, false, "");

							foreach (var subSubElem in typesSubdir)
							{
								string tentacleSubtypeDir = subSubElem.Key;
								List<string> typesSubsubdir = subSubElem.Value;

								string testTypePath = Path.Combine(typePath, tentacleSubtypeDir);
								FindOrCreate(testTypePath);
								// initPath = Path.Combine(testTypePath, TentaclesManagerVariables.PYTHON_INIT_FILE);
								// FindOrCreate(initPath, false, "");

								CreateArchModuleExtremity(tentacleExtremityArchitecture, typesSubsubdir, testTypePath, false, false);
							}
						}
					}
					else
					{
						Debug.WriteLine(type.ToString());

						Debug.WriteLine(1);
					}
				}
			}

			return foundExistingInstallation;
		}
		public static void CreateArchModuleExtremity(List<string> architecture, List<string> typesSubdir, string typePath, bool withInitConfig = true, bool withInitRes = true)
		{
			foreach (var moduleType in typesSubdir)
			{
				string path = Path.Combine(typePath, moduleType);
				FindOrCreate(path);

				foreach (var extremityFolder in architecture)
				{
					string moduleContentPath = Path.Combine(path, extremityFolder);
					// add Advanced etc folders
					FindOrCreate(moduleContentPath);

					// initPath = Path.Combine(moduleContentPath, TentaclesManagerVariables.PYTHON_INIT_FILE);
					// FindOrCreate(initPath, false, "");
				}

				// add init.py file
				// initPath = Path.Combine(moduleContentPath, TentaclesManagerVariables.PYTHON_INIT_FILE);
				// FindOrCreate(initPath, false, "");

				if (withInitConfig == true)
				{
					string moduleConfigPath = Path.Combine(path, TentaclesManagerVars.EVALUATOR_CONFIG_FOLDER);
					FindOrCreate(moduleConfigPath);
					string moduleDefaultConfigPath = Path.Combine(moduleConfigPath, TentaclesManagerVars.EVALUATOR_DEFAULT_FOLDER);
					FindOrCreate(moduleDefaultConfigPath);
				}

				if (withInitRes == true)
				{
					string moduleResPath = Path.Combine(path, TentaclesManagerVars.EVALUATOR_RESOURCE_FOLDER);
					FindOrCreate(moduleResPath);
				}
			}
		}
		public static (Dictionary<string, List<object>>, List<string>) GetTentaclesArch()
		{
			Dictionary<string, List<string>> tentaclesContentFolder = new Dictionary<string, List<string>>()
			{
				{
					TentaclesManagerVars.TENTACLES_EVALUATOR_PATH, new List<string>() {
						TentaclesManagerVars.TENTACLES_EVALUATOR_REALTIME_PATH,
						TentaclesManagerVars.TENTACLES_EVALUATOR_SOCIAL_PATH,
						TentaclesManagerVars.TENTACLES_EVALUATOR_TA_PATH,
						TentaclesManagerVars.TENTACLES_EVALUATOR_STRATEGIES_PATH,
						TentaclesManagerVars.TENTACLES_EVALUATOR_UTIL_PATH
					}
				},
				{
					TentaclesManagerVars.TENTACLES_TRADING_PATH, new List<string>()
					{
						TentaclesManagerVars.TENTACLES_TRADING_MODE_PATH
					}
				}
			};

			Dictionary<string, List<object>> tentacleArchitecture = new Dictionary<string, List<object>>()
			{
				{ TentaclesManagerVars.TENTACLES_PATH, new List<object>()
				{
					tentaclesContentFolder, new Dictionary<string, Dictionary<string, List<string>>>()
					{
						{ TentaclesManagerVars.TENTACLES_TEST_PATH, tentaclesContentFolder }
					}
				}}
			};

			List<string> tentacleExtremityArchitecture = TentaclesManagerVars.TENTACLES_INSTALL_FOLDERS;

			return (tentacleArchitecture, tentacleExtremityArchitecture);
		}
		public static bool FindOrCreate(string path, bool isDirectory = true, object fileContent = null)
		{
			//if (fileContent == null) fileContent = TENTACLES_PYTHON_INIT_CONTENT;

			if (FileUtilities.FileExists(path) == false)
			{
				if (isDirectory == true)
				{
					if (FileUtilities.DirectoryExits(path) == false)
					{
						FileUtilities.DirectoryMake(path);
					}
				}
				else
				{
					if (FileUtilities.FileExists(path) == false)
					{
						Debug.WriteLine(1);
					}
				}

				return true;
			}

			return false;
		}
		public static Dictionary<string, object> ParseModuleHeader(TentacleModule moduleHeaderContent)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>()
			{
				{ TentaclesManagerVars.TENTACLE_MODULE_NAME, moduleHeaderContent.Name },
				{ TentaclesManagerVars.TENTACLE_MODULE_TYPE, moduleHeaderContent.Type },
				{ TentaclesManagerVars.TENTACLE_MODULE_SUBTYPE, moduleHeaderContent.Subtype != "" ? moduleHeaderContent.Subtype : "" },
				{ TentaclesManagerVars.TENTACLE_MODULE_VERSION, moduleHeaderContent.Version },
				{ TentaclesManagerVars.TENTACLE_MODULE_REQUIREMENTS, ExtractTentacleRequirements(moduleHeaderContent) },
				{ TentaclesManagerVars.TENTACLE_MODULE_TESTS, ExtractTentacleTests(moduleHeaderContent) },
				{ TentaclesManagerVars.TENTACLE_MODULE_CONFIG_FILES, moduleHeaderContent.ConfigFiles != null ? moduleHeaderContent.ConfigFiles : null },
				{ TentaclesManagerVars.TENTACLE_MODULE_CONFIG_SCHEMA_FILES, moduleHeaderContent.ConfigSchemaFiles != null ? moduleHeaderContent.ConfigSchemaFiles : null },
				{ TentaclesManagerVars.TENTACLE_MODULE_RESOURCE_FILES, moduleHeaderContent.ResourceFiles != null ? moduleHeaderContent.ResourceFiles : null },
				{ TentaclesManagerVars.TENTACLE_MODULE_DEV, moduleHeaderContent.Developing != null ? moduleHeaderContent.Developing : false },
				{ TentaclesManagerVars.TENTACLE_PACKAGE, moduleHeaderContent.PackageName != "" ? moduleHeaderContent.PackageName : "???" }
			};

			return dict;
		}
		public static List<Dictionary<string, string>> ExtractTentacleRequirements(TentacleModule module)
		{
			if (module.Requirements != null && module.Requirements.Count > 0)
			{
				var requirements = new List<string>();

				foreach (var component in module.Requirements)
				{
					requirements.Add(component);
				}

				var value = new List<Dictionary<string, string>>();
				foreach (var req in requirements)
				{
					value.Add(ParseRequirements(req));
				}

				return value;
			}

			return null;
		}
		public static Dictionary<string, string> ParseRequirements(string requirement)
		{
			string[] requirementInfo = requirement.Split(TentaclesManagerVars.TENTACLE_MODULE_REQUIREMENT_VERSION_SEPARATOR);

			Dictionary<string, string> dict = new Dictionary<string, string>()
			{
				{ TentaclesManagerVars.TENTACLE_MODULE_NAME, requirementInfo[0] },
				{ TentaclesManagerVars.TENTACLE_MODULE_VERSION, requirementInfo.Length > 1 ? requirementInfo[1] : "" },
				{ TentaclesManagerVars.TENTACLE_MODULE_REQUIREMENT_WITH_VERSION, requirement }
			};

			return dict;
		}
		public static List<string> ExtractTentacleTests(TentacleModule module)
		{
			if (module.Tests != null && module.Tests.Count > 0)
			{
				var tests = new List<string>();

				foreach (var component in module.Tests)
				{
					tests.Add(component);
				}

				var value = new List<string>();
				foreach (var test in tests)
				{
					value.Add(test);
				}

				return value;
			}

			return null;
		}
		public static void ParseModuleFile(object moduleFileContent, object descriptionList)
		{
			Debug.WriteLine(1);
		}
		public static string CreateLocalizationFromType(Uri localization, TypeEnum moduleType, string moduleSubtype, string file, bool tests = false)
		{
			// create path from types
			string testFolderIfRequired = "";

			if (tests == true) testFolderIfRequired = $"/{TentaclesManagerVars.TENTACLES_TEST_PATH}";

			if (moduleSubtype != "") return $"{localization}{testFolderIfRequired}/{moduleType}/{moduleSubtype}/{file}";
			else return $"{localization}{testFolderIfRequired}/{moduleType}/{file}";
		}
		public static string CreatePathFromType(TypeEnum moduleType, string moduleSubtype, string targetFolder, bool tests = false)
		{
			// create path from types
			string testFolderIfRequired = "";

			if (tests == true) testFolderIfRequired = $"/{TentaclesManagerVars.TENTACLES_TEST_PATH}";

			string value = "";

			string mt = moduleType.ToString();
			string mtv = "";
			string mst = "";

			foreach (var index in TentaclesManagerVars.TENTACLE_TYPES)
			{
				foreach (var subIndex in index)
				{
					if (subIndex.Key == mt) mtv = subIndex.Value;
					if (subIndex.Key == moduleSubtype) mst = subIndex.Value;
				}
			}

			if (moduleSubtype != "") value = $"{TentaclesManagerVars.TENTACLES_PATH}{testFolderIfRequired}/{mtv}/" + $"{mst}/{targetFolder}";
			else value = $"{TentaclesManagerVars.TENTACLES_PATH}{testFolderIfRequired}/{mtv}/{targetFolder}";

			return value;
		}
		public static string GetFullModuleIdentifier(string moduleName, string moduleVersion)
		{
			return $"{moduleName}{TentaclesManagerVars.TENTACLE_MODULE_REQUIREMENT_VERSION_SEPARATOR}{moduleVersion}";
		}
		public static List<int> ParseVersion(string version)
		{
			List<int> value = new List<int>();
			string[] splited = version.Split(".");
			foreach (var val in splited)
			{
				try
				{
					value.Add(Convert.ToInt32(val));
				}
				catch { }
			}

			return value;
		}
		public static bool IsFirstVersionSuperior(string firstVersion, string secondVersion, bool orEqual = false)
		{
			var firstVersionData = ParseVersion(firstVersion);
			var secondVersionData = ParseVersion(secondVersion);

			if (secondVersionData.Count > firstVersionData.Count) return false;
			else
			{
				if (orEqual == true && firstVersionData == secondVersionData) return true;

				for (int index = 0; index < firstVersionData.Count; index++)
				{
					int value = firstVersionData[index];
					if (secondVersionData.Count > index && secondVersionData[index] > value) return false;
				}
			}

			return firstVersionData != secondVersionData;
		}
		public static bool IsModuleInList(string moduleName, string moduleVersion, List<string> moduleList)
		{
			if (moduleVersion == "")
			{
				bool value = false;

				foreach (var module in moduleList)
				{
					if (module.Split(TentaclesManagerVars.TENTACLE_MODULE_REQUIREMENT_VERSION_SEPARATOR)[0] == moduleName) value = true;
				}

				return value;
			}
			else
			{
				return (moduleList.Contains(GetFullModuleIdentifier(moduleName, moduleVersion)));
			}
		}
		public static bool InstallOnDevelopment(ICoreConfig config, bool? moduleDev)
		{
			// is not on development
			if (moduleDev == null || moduleDev == false) return true;

			// is on development
			if (moduleDev == true && config.DevMode != null && config.DevMode == true) return true;

			return false;
		}
		public static void ParsePackage(object tentacleContent)
		{
			Debug.WriteLine(1);
		}
		public static void ReadTentacle(object fileName)
		{
			Debug.WriteLine(1);
		}
		public static void CheckTentacle(object path, object tentacle, bool verbose = true)
		{
			Debug.WriteLine(1);
		}
	}
}