using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using OctoBot.Config;
using OctoBot.Core;
using OctoBot.Utils;
using Serilog.Core;

namespace OctoBot.Tools
{
	public static class ConfigManager
	{
		public static void SaveConfig(object configFile, object config, object tempRestoreConfigFile, object jsonData = null)
		{
			Debug.WriteLine(1);
		}
		public static (bool, string) ValidateConfigFile(ConfigJson config = null, string schemaFile = null)
		{
			if (schemaFile == null) schemaFile = ConfigVars.CONFIG_FILE_SCHEMA;

			try
			{
				JSchema schema = JSchema.Parse(FileUtilities.GetFileContents(schemaFile));

				var configJO = JObject.Parse(config.ToJson());

				bool valid = configJO.IsValid(schema);
			}
			catch (Exception exc)
			{
				Debug.WriteLine(1);

				return (false, exc.Message);
			}

			return (true, "");
		}
		public static void ConfigHealthCheck(Logger logger, ConfigJson config)
		{
			// 1 ensure api key encryption
			bool shouldReplaceConfig = false;

			if (config.Exchanges != null)
			{
				foreach (var exch in config.Exchanges)
				{
					string exchange = exch.Key;
					Exchange exchangeConfig = exch.Value;

					foreach (var key in ConfigVars.CONFIG_EXCHANGE_ENCRYPTED_VALUES)
					{
						try
						{
							if (ConfigManager.HandleEncryptedValue(logger, key, exchangeConfig, true) == false)
							{
								shouldReplaceConfig = true;
							}
						}
						catch (Exception exc)
						{
							logger.Error($"Вызвано исключение при проверке шифрования конфигурации биржи: {exc.Message}");
						}
					}
				}
			}

			// 2 ensure single trader activated
			bool traderEnabled = ConfigManager.GetTraderEnabled(config);
			if (traderEnabled == true)
			{
				Debug.WriteLine(1);
			}

			// 3 save fixed config if necessary
			if (shouldReplaceConfig == true)
			{
				Debug.WriteLine(1);
			}
		}
		public static void RestoreConfig(object restoreFile, object targetFile)
		{
			Debug.WriteLine(1);
		}
		public static void PrepareRestoreFile(object restoreFile, object currentConfigFile)
		{
			Debug.WriteLine(1);
		}
		public static void RemoveRestoreFile(object restoreFile)
		{
			Debug.WriteLine(1);
		}
		public static bool HandleEncryptedValue(Logger logger, string valueKey, Exchange configElement, bool verbose = false)
		{
			string key = "";

			switch (valueKey)
			{
				case "api-key":
					key = configElement.ApiKey;
					break;
				case "api-secret":
					key = configElement.ApiSecret;
					break;
				case "api-password":
					key = configElement.ApiPassword;
					break;
			}

			if (ConfigManager.HasInvalidDefaultConfigValue(key) == false && key != null)
			{
				try
				{
					// decrypt(key, silent_on_invalid_token=True)
					return true;
				}
				catch (Exception exc)
				{
					//config_element[value_key] = encrypt(key).decode()
					if (verbose == true)
					{
						logger.Warning($"В конфигурации найдена не зашифрованная секретная информация ({valueKey}): заменено на " + $"зашифрованное значение.");
					}
					return false;
				}
			}

			return true;
		}
		public static void JsonifyConfig(object config)
		{
			Debug.WriteLine(1);
		}
		public static void DumpJson(object jsonData)
		{
			Debug.WriteLine(1);
		}
		public static void CheckConfig(object configFile)
		{
			Debug.WriteLine(1);
		}
		public static bool IsInDevMode(ICoreConfig config)
		{
			// return True если "DEV-MODE": true в config.json
			return (bool)config.DevMode;
		}
		public static void UpdateEvaluatorConfig(object toUpdateData, object currentConfig, object deactivateOthers)
		{
			Debug.WriteLine(1);
		}
		public static void UpdateTradingConfig(object toUpdateData, object currentConfig)
		{
			Debug.WriteLine(1);
		}
		public static void RemoveLoadedOnlyElement(object config)
		{
			Debug.WriteLine(1);
		}
		public static void FilterToUpdateData(object toUpdateData, object currentConfig)
		{
			Debug.WriteLine(1);
		}
		public static void UpdateGlobalConfig(object toUpdateData, object currentConfig, bool updateInput = false, bool delete = false)
		{
			Debug.WriteLine(1);
		}
		public static void SimpleSaveConfigUpdate(object updatedConfig)
		{
			Debug.WriteLine(1);
		}
		public static void ParseAndUpdate(object key, object newData)
		{
			Debug.WriteLine(1);
		}
		public static void AreOfCompatibleType(object val1, object val2)
		{
			Debug.WriteLine(1);
		}
		public static void MergeDictionariesByAppendingKeys(object dictDest, object dictSrc)
		{
			Debug.WriteLine(1);
		}
		public static void ClearDictionariesByKeys(object dictDest, object dictSrc)
		{
			Debug.WriteLine(1);
		}
		public static void UpdateActivationConfig(object toUpdateData, object currentConfig, object configFilePath, object configFile, object deactivateOthers)
		{
			Debug.WriteLine(1);
		}
		public static void UpdateTentacleConfig(object klass, object configUpdate)
		{
			Debug.WriteLine(1);
		}
		public static void FactoryResetTentacleConfig(object klass)
		{
			Debug.WriteLine(1);
		}
		public static void ReloadTentacleConfig(ICoreConfig config)
		{
			var a = ConfigBase.LoadConfig(ConfigVars.CONFIG_EVALUATOR_FILE_PATH, false);

			//config.Evaluator = ConfigBase.LoadConfig(ConfigVars.CONFIG_EVALUATOR_FILE_PATH, false);
			//if (config.Evaluator == null) throw new ConfigEvaluatorError();

			Debug.WriteLine(1);
		}
		public static bool HasInvalidDefaultConfigValue(string configValues)
		{
			return ConfigVars.DEFAULT_CONFIG_VALUES.Contains(configValues);
		}
		public static void GetSymbols(object config)
		{
			Debug.WriteLine(1);
		}
		public static void GetAllCurrencies(object config)
		{
			Debug.WriteLine(1);
		}
		public static void GetPairs(object config, object currency)
		{
			Debug.WriteLine(1);
		}
		public static void GetMarketPair(object config, object currency)
		{
			Debug.WriteLine(1);
		}
		public static void GetReferenceMarket(object config)
		{
			Debug.WriteLine(1);
		}
		public static void GetMetricsEnabled(object config)
		{
			Debug.WriteLine(1);
		}
		public static bool GetTraderEnabled(ConfigJson config)
		{
			return config.Trader.Enabled;
		}
		public static void GetTraderSimulatorEnabled(object config)
		{
			Debug.WriteLine(1);
		}
		public static bool AcceptedTerms(ICoreConfig config)
		{
			return config.AcceptedTerms;
		}
		public static void AcceptTerms(object config, object accepted)
		{
			Debug.WriteLine(1);
		}
	}
}