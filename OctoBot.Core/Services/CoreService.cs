using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArgParse;
using OctoBot.Config;
using OctoBot.Tools;

namespace OctoBot.Core
{
	internal class CoreService : ConfigrableServiceBase<CoreConfig>, ICoreService
	{
		private List<string> DISCLAIMER = new List<string>()
		{
			"Do not risk money which you are afraid to lose. USE THE SOFTWARE AT YOUR OWN RISK. THE AUTHORS AND ALL ",
			"AFFILIATES ASSUME NO RESPONSIBILITY FOR YOUR TRADING RESULTS.",
			"Always start by running a trading bot in simulation mode and do not engage money before you understand ",
			"how it works and what profit/loss you should expect.",
			"Do not hesitate to read the source code and understand the mechanism of this bot."
		};

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

						// ConfigManager.ReloadTentacleConfig(Config);

						if (parseResult["data_collector"] != null)
						{
							Debug.WriteLine(1);
						}
						else if (parseResult["strategy_optimizer"] != null)
						{
							Debug.WriteLine(1);
						}
						else
						{
							// При этом условии загружаем OctoBot
							// TelegramApp.enable(Config, parseResult["no_telegram"] == null);
							// WebService.enable(Config, parseResult["no_web"] == null);

							UpdateConfigWithArgs(parseResult, Config);

							bool resetTradingHistory = parseResult["reset_trading_history"] != null ? (bool)parseResult["reset_trading_history"] : false;

							var bot = new OctoBot(Config, resetTradingHistory: resetTradingHistory);

							LogTermsIfUnaccepted(Config);

							bool noOpenWeb = parseResult["no_open_web"] != null ? (bool)parseResult["no_open_web"] : false;
							bool noWeb = parseResult["no_web"] != null ? (bool)parseResult["no_web"] : false;

							if (noOpenWeb == false && noWeb == false)
							{
								Debug.WriteLine(1);
							}

							// Установите debug_mode = true для активвации режима отладки в asyncio
							var debugMode = ConfigManager.IsInDevMode(Config) || ConfigVars.FORCE_ASYNCIO_DEBUG_OPTION;
							var t = Task.Run(() => Commands.StartBot(bot));
						}
					}
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
		private void UpdateConfigWithArgs(ParseResult parseResult, ICoreConfig config)
		{
			if (parseResult["backtesting"] != null)
			{
				config.Backtesting.Enabled = true;
				config.Backtesting.PostAnalysisEnabled = (bool)parseResult["backtesting_analysis"];

				config.Notification.Enabled = false;

				config.Trader.Enabled = false;
				config.TraderSimulator.Enabled = true;
			}

			if (parseResult["simulate"] != null)
			{
				config.Trader.Enabled = false;
				config.TraderSimulator.Enabled = true;
			}

			if (parseResult["risk"] != null)
			{
				decimal risk = (decimal)parseResult["risk"];

				if (0 < risk && risk <= 1) config.Trading.Risk = risk;
			}
		}
		private void LogTermsIfUnaccepted(ICoreConfig config)
		{
			if (ConfigManager.AcceptedTerms(Config) == false)
			{
				loggingService.Info("*** Disclaimer ***");
				foreach (var line in DISCLAIMER)
				{
					loggingService.Info(line);
				}
				loggingService.Info("... Disclaimer ...");
			}
			else loggingService.Info("Отказ от ответственности принят пользователем.");
		}
		private void AutoOpenWeb(ICoreConfig config, OctoBot bot)
		{
			try
			{
				// Ожидаем готовность бота к работе
				while (bot.IsReady() == false)
				{
					Thread.Sleep(100);
				}

				//webbrowser.open(String.Format("http://{0}:{1}", socket.gethostbyname(socket.gethostname()), config.Services[] [CONFIG_WEB][CONFIG_WEB_PORT]);
			}
			catch (Exception exc)
			{
				loggingService.Error(String.Format("{0}, невозможно автоматически открыть веб-интерфейс", exc.Message));
			}
		}
	}
}
