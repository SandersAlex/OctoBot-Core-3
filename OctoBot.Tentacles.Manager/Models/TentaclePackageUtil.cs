using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OctoBot.Config;
using OctoBot.Core;
using OctoBot.TentaclesManagement;
using OctoBot.Utils;
using Serilog.Core;

namespace OctoBot.Tentacles.Manager
{
	public static class TentaclePackageUtil
	{
		public static void GetPackageDescriptionWithAdaptation(object urlOrPath, object gitBranch = null)
		{
			//if (gitBranch == null) gitBranch = TENTACLES_DEFAULT_BRANCH;

			Debug.WriteLine(1);
		}
		public static TentaclesListJson GetPackageDescription(string urlOrPath, bool tryToAdapt = false, string gitBranch = "")
		{
			if (gitBranch == "") gitBranch = TentaclesManagerVars.TENTACLES_DEFAULT_BRANCH;

			string packageUrlOrPath = urlOrPath;

			// if its an url: download with requests.get and return text
			if (GetIsUrl(packageUrlOrPath) == true)
			{
				if (tryToAdapt == true)
				{
					if (packageUrlOrPath.EndsWith("/") == false) packageUrlOrPath += "/";

					// if checking on github, try adding branch and file
					if (packageUrlOrPath.Contains(TentaclesManagerVars.GITHUB) == true) packageUrlOrPath += $"{gitBranch}/{TentaclesManagerVars.TENTACLES_PUBLIC_LIST}";
					// else try adding file
					else packageUrlOrPath += TentaclesManagerVars.TENTACLES_PUBLIC_LIST;
				}

				TentaclesListJson downloadedResult = TentaclesListJson.FromJson(FileUtilities.GetFileContents($"Config/{TentaclesManagerVars.TENTACLES_PUBLIC_LIST}"));

				PropertyInfo[] lst = downloadedResult.GetType().GetProperties();
				foreach (PropertyInfo pi in lst)
				{
					var type = pi.PropertyType;
					if (type == typeof(TentacleModule))
					{
						downloadedResult.ListPuneHedgehog.Add(pi.Name, (TentacleModule)pi.GetValue(downloadedResult));
					}
				}

				if (downloadedResult == null && packageUrlOrPath.Contains(TentaclesManagerVars.GITHUB_BASE_URL) == true)
				{
					Debug.WriteLine(1);
				}

				// add package metadata
				AddPackageDescriptionMetadata(downloadedResult, packageUrlOrPath, true);

				return downloadedResult;
			}
			// if its a local path: return file content
			else
			{
				Debug.WriteLine(1);

				return null;
			}
		}
		public static bool GetIsUrl(string str)
		{
			return str.StartsWith("https://") || str.StartsWith("http://") || str.StartsWith("ftp://");
		}
		public static void AddPackageDescriptionMetadata(TentaclesListJson packageDescription, string localisation, bool isUrl)
		{
			string toSaveLoc = localisation;

			if (localisation.EndsWith(TentaclesManagerVars.TENTACLES_PUBLIC_LIST) == true)
			{
				toSaveLoc = localisation.Substring(0, localisation.Length - TentaclesManagerVars.TENTACLES_PUBLIC_LIST.Length);

				while (toSaveLoc.EndsWith("/") || toSaveLoc.EndsWith("\\"))
				{
					toSaveLoc = toSaveLoc.Substring(0, toSaveLoc.Length - 1);
				}
			}

			if (packageDescription.PackageDescription == null) packageDescription.PackageDescription = new PackageDescription()
			{
				Localisation = new Uri(toSaveLoc),
				Name = GetPackageName(localisation, isUrl),
				IsUrl = isUrl
			};
			else
			{
				packageDescription.PackageDescription.Localisation = new Uri(toSaveLoc);
				packageDescription.PackageDescription.Name = GetPackageName(localisation, isUrl);
				packageDescription.PackageDescription.IsUrl = isUrl;
			}
		}
		public static string GetOctobotTentaclePublicRepo(bool toDescriptionFile = true, string gitBranch = "")
		{
			if (gitBranch == "") gitBranch = TentaclesManagerVars.TENTACLES_DEFAULT_BRANCH;

			if (toDescriptionFile == true) return $"{TentaclesManagerVars.GITHUB_BASE_URL}/{TentaclesManagerVars.TENTACLES_PUBLIC_REPOSITORY}/{gitBranch}/{TentaclesManagerVars.TENTACLES_PUBLIC_LIST}";
			else return $"{TentaclesManagerVars.GITHUB_BASE_URL}/{TentaclesManagerVars.TENTACLES_PUBLIC_REPOSITORY}";
		}
		public static string AddPackageName(string moduleFileContent, string packageName)
		{
			return moduleFileContent.Replace("$tentacle_description: {\n", "$tentacle_description: {\n    " + $"\"package_name\": \"{packageName}\",\n");
		}
		public static string GetPackageName(string localisation, bool isUrl)
		{
			if (isUrl == true)
			{
				int githubPackageNameReverseIndex = localisation.EndsWith(".json") == true ? -3 : -1;
				string[] splited = localisation.Split("/");
				var value = splited[splited.Length + githubPackageNameReverseIndex];

				return value;
			}
			else
			{
				int localPackageNameReverseIndex = localisation.EndsWith(".json") == true ? -2 : -1;
				string separator = "/";
				if (localisation.Contains("\\") == true) separator = "\\";
				string[] splited = localisation.Split(separator);
				var value = splited[splited.Length + localPackageNameReverseIndex];

				return value;
			}
		}
		public static string GetPackageFileContentFromUrl(string url, bool asBytes = false)
		{
			string result = TaskGetPackageFileContentFromUrl(url, "").Result;

			return result;
		}
		public static void ReadTentacles(object path, object descriptionList)
		{
			Debug.WriteLine(1);
		}
		public static bool ShouldRecreateConfigFile(string filePath, string configFileContent)
		{
			return FileUtilities.FileExists(filePath) == false && configFileContent != "";
		}
		public static void CheckPath(object path)
		{
			Debug.WriteLine(1);
		}
		public static void UpdateConfigFile(string configFilePath, string defaultFilePath, List<Type> classesToConsider)
		{
			// initialize file content
			Dictionary<string, object> configContent = new Dictionary<string, object>();
			bool changedSomething = false;
			string defaultConfigFileContent = "";

			if (FileUtilities.FileExists(configFilePath) == true)
			{
				try
				{
					defaultConfigFileContent = FileUtilities.GetFileContents(configFilePath);
					Debug.WriteLine(1);
				}
				catch (Exception exc)
				{
					var logger = Application.Resolve<ILoggingService>();
					logger.Warning($"Невозможно загрузить контент из файла конфигурации: " + $"{configFilePath}: {exc.Message}");
				}
			}

			// take default values into account using default file
			if (FileUtilities.FileExists(defaultFilePath) == true)
			{
				defaultConfigFileContent = FileUtilities.GetFileContents(defaultFilePath);
				Debug.WriteLine(1);
			}

			List<object> classesList = new List<object>();
			// add items using their base class key (vs advances classes)
			foreach (var classesInConfig in classesToConsider)
			{
				changedSomething = AddClassToConfigFileContent(classesInConfig, configContent, classesList) || changedSomething;
			}

			Debug.WriteLine(1);
		}
		public static bool AddClassToConfigFileContent(Type clazz, Dictionary<string, object> configFileContent, List<object> classesList, bool activated = false)
		{
			//bool useFirst = TentacleUtil.IsFirstVersionSuperior(ConfigVars.SHORT_VERSION, TentaclesManagerVars.OCTOBOT_ADV_MNG_IMPORT_CHANGE_VERSION, orEqual: true);

			bool changedSomething = false;
			var currentClassesList = AdvancedManager.CreateDefaultTypesList(clazz);

			Debug.WriteLine(1);

			return false;
		}

		public static Task<string> TaskGetPackageFileContentFromUrl(string url, string contentType = "")
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			if (contentType != "") request.ContentType = contentType;
			request.Method = WebRequestMethods.Http.Get;
			request.Timeout = 20000;
			request.Proxy = null;

			try
			{
				Task<WebResponse> task = Task.Factory.FromAsync(
				 request.BeginGetResponse,
				 asyncResult => request.EndGetResponse(asyncResult),
				 (object)null);

				return task.ContinueWith(t => GetPackageFileContentFromUrlResponse(t.Result));
			}
			catch (Exception exc)
			{
				Debug.WriteLine($"Ошибка в TaskGetPackageFileContentFromUrl: url = {url} contentType = {contentType}");

				return null;
			}
		}
		private static string GetPackageFileContentFromUrlResponse(WebResponse response)
		{
			using (Stream responseStream = response.GetResponseStream())
			using (StreamReader sr = new StreamReader(responseStream))
			{
				//Need to return this response 
				string strContent = sr.ReadToEnd();
				return strContent;
			}
		}
	}
}
