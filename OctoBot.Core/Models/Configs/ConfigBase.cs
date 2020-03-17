using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using OctoBot.Core;
using OctoBot.Tools;
using OctoBot.Utils;
using Serilog.Core;

namespace OctoBot.Config
{
	public static class ConfigBase
	{
		public static string GetUserConfig()
		{
			return Path.Combine(ConfigVars.USER_FOLDER, ConfigVars.CONFIG_FILE);
		}
		public static ConfigJson LoadConfig(string configFile = "", bool error = true, bool fillMissingFields = false)
		{
			if (configFile == "") configFile = GetUserConfig();

			string basicError = String.Format("Ошибка открытия файла конфигурации {0}", configFile);

			try
			{
				var config = ConfigJson.FromJson(FileUtilities.GetFileContents(configFile));

				//if (fillMissingFields == true) FillMissingConfigFields(logger, config);

				return config;
			}
			catch (IOException exc)
			{
				string errorStr = String.Format("{0} : ошибка открытия файла ({1})", basicError, exc.Message);

				var logger = Application.Resolve<ILoggingService>();
				logger.Error(errorStr);
			}
			catch (Exception exc)
			{
				Debug.WriteLine(1);
			}

			return null;
		}
		public static void InitConfig(string configFile = "", string fromConfigFile = "")
		{
			if (configFile == "") configFile = GetUserConfig();
			if (fromConfigFile == "") fromConfigFile = ConfigVars.DEFAULT_CONFIG_FILE;

			try
			{
				if (FileUtilities.DirectoryExits(ConfigVars.USER_FOLDER) == false) FileUtilities.DirectoryMake(ConfigVars.USER_FOLDER);

				File.Copy(fromConfigFile, configFile);
			}
			catch (Exception exc)
			{
				Debug.WriteLine(1);
			}
		}
		public static bool IsConfigEmptyOrMissing(string configFile = "")
		{
			if (configFile == "") configFile = GetUserConfig();

			return !FileUtilities.FileExists(configFile) || FileUtilities.FileSize(configFile) == 0;
		}
		public static void Encrypt(object data)
		{
			Debug.WriteLine(1);
		}
		public static void Decrypt(object data, bool silentOnInvalidToken = false)
		{
			Debug.WriteLine(1);
		}
		public static void FillMissingConfigFields(ConfigJson config, string referenceConfigFile = "")
		{
			if (referenceConfigFile == "") referenceConfigFile = ConfigVars.DEFAULT_CONFIG_FILE;

			try
			{
				ConfigJson defaultConfig = LoadConfig(referenceConfigFile);

				List<string> exceptionList = new List<string>() { ConfigVars.CONFIG_CRYPTO_CURRENCIES, ConfigVars.CONFIG_STARTING_PORTFOLIO, ConfigVars.CONFIG_EXCHANGES, ConfigVars.CONFIG_CATEGORY_SERVICES };

				DictUtil.CheckAndMergeValuesFromReference(config, defaultConfig, exceptionList);
			}
			catch (Exception exc)
			{
				var logger = Application.Resolve<ILoggingService>();
				logger.Warning($"Невозможно проверить целостность файла конфигурации ({exc.Message})");
			}
		}
	}
}
