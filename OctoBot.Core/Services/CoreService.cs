using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using ArgParse;
using OctoBot.Config;
using OctoBot.Tools;

namespace OctoBot.Core
{
	internal class CoreService : ConfigrableServiceBase<CoreConfig>, ICoreService
	{
		public override string ServiceName => Constants.ServiceNames.CoreService;

		ICoreConfig ICoreService.Config => Config;

		private readonly ILoggingService loggingService;
		private readonly ITentacleManagerService tentacleManagerService;

		public CoreService(ILoggingService loggingService, ITentacleManagerService tentacleManagerService)
		{
			this.loggingService = loggingService;
			this.tentacleManagerService = tentacleManagerService;

			// Set decimal separator to a dot for all cultures
			var cultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);
			cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
			CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
			CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
		}

		public void Start(ParseResult parseResult)
		{
			try
			{
				if (parseResult["version"] != null)
				{
					Debug.WriteLine(1);
				}
				else
				{
					loggingService.Info($"Запуск OctoBot Core. Версия: {ConfigVars.LONG_VERSION}");

					CheckPublicAnnouncements();

					loggingService.Info("Загрузка файлов конфигурации...");

					// загрузка конфигурации
					// ConfigJson config = ConfigBase.LoadConfig(logger, "", false, true);

					if (Config == null /*&& ConfigBase.IsConfigEmptyOrMissing() == true*/)
					{
						Debug.WriteLine(1);

						/*Log.Information("Конфигурация не была найдена. Создаём файл конфигурации по умолчанию...");

						ConfigBase.InitConfig();

						config = ConfigBase.LoadConfig(logger, "", false);*/
					}
					else
					{
						Debug.WriteLine(1);

						/*(bool isValid, string e) tuple = ConfigManager.ValidateConfigFile(config);
						if (tuple.isValid == false)
						{
							logger.Error("OctoBot не может починить Ваш файл config.json: неверный json формат: " + tuple.e);

							throw new ConfigError();
						}

						ConfigManager.ConfigHealthCheck(logger, config);*/
					}

					if (Config == null) throw new ConfigError();

					// Если возможно, то обрабатываем служебные методы перед инициализацией бота
					if (parseResult["packager"] != null)
					{
						Debug.WriteLine(1);
					}
					else if (parseResult["creator"] != null)
					{
						Debug.WriteLine(1);
					}
					else if (parseResult["encrypter"] != null)
					{
						Debug.WriteLine(1);
					}
					else
					{
						if (tentacleManagerService.TentaclesArchExists() == false)
						{
							loggingService.Info("Tentacles не найдены. Установка tentacles по умолчанию...");
							Commands.PackageManager(tentacleManagerService, Config, new List<string>() { "install", "all" }, force: true);
						}

						Debug.WriteLine(1);
					}

					Debug.WriteLine(1);
				}
			}
			catch (ConfigError exc)
			{
				Debug.WriteLine(1);
			}
			catch (ConfigEvaluatorError exc)
			{
				Debug.WriteLine(1);
			}
			catch (ConfigTradingError exc)
			{
				Debug.WriteLine(1);
			}
			catch (Exception exc)
			{
				Debug.WriteLine(1);
			}
		}
		public void Stop()
		{
			throw new NotImplementedException();
		}
		public void Restart()
		{
			throw new NotImplementedException();
		}

		private void CheckPublicAnnouncements()
		{
			string announcement = ExternalResourcesManager.GetExternalResource(ConfigVars.EXTERNAL_RESOURCE_PUBLIC_ANNOUNCEMENTS);

			if (!string.IsNullOrEmpty(announcement))
			{
				loggingService.Info($"Анонс: {announcement}");
			}
		}
	}
}
