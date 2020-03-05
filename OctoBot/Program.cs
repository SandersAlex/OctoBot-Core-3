using System;
using System.Collections.Generic;
using System.Diagnostics;
using ArgParse;
using ArgParse.Enums;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using OctoBot.Config;
using OctoBot.Core;
using OctoBot.Tentacles.Manager;
using OctoBot.Tools;
using Serilog;
using Serilog.Core;

namespace OctoBot
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ArgumentParser parser = new ArgumentParser(new ParserSettings() { Description = "OctoBot" });
				parser.AddArgument(new Argument("-v", "--version") { HelpText = "Отображает текущую версию OctoBot.", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("-s", "--simulate") { HelpText = "Принудительный запуск OctoBot только с симулятором торговых операций.", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("-rts", "--reset-trading-history") { HelpText = "Принудительный сброс истории торговых операций. Теперь берется следующий портфель в качестве ориентира прибыльности, а симуляторы торговых операций будут использовать новый портфель.", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("-d", "--data_collector") { HelpText = "Запуск процесс сбора данных, чтобы их использовать в тестировании на исторических данных.", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("-b", "--backtesting") { HelpText = "Запуск OctoBot в режиме тестирования на исторических данных, используйте конфигурацию тестирования на исторических данных, сохраненную в config.json.", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("-ba", "--backtesting_analysis") { HelpText = "Дополнительный аргумент для того, чтобы не останавливать бота в конце тестирования на исторических данных (полезно анализировать такие результаты, используя визуальные интерфейсы, например - веб-интерфейс).", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("-r", "--risk") { Type = typeof(decimal), HelpText = "Принудительное определение значения конкретной конфигурации риска (от 0 до 1)." });
				parser.AddArgument(new Argument("-nw", "--no_web") { HelpText = "Отключение запуска веб-интерфейса OctoBot.", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("-no", "--no_open_web") { HelpText = "Отключение автоматического отрытия веб-интерфейса.", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("-nt", "--no_telegram") { HelpText = "Запустите OctoBot без интерфейса Telegram, даже если учетные данные Telegram находятся в конфигурации. Интерфейс Telegram необходим для прослушивания сигналов Telegram и обсуждения с OctoBot по Telegram.", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("--encrypter") { HelpText = "Запускаем обмен api ключей шифратора. Этот инструмент полезен для ручного добавления конфигурации бирж в ваш config.json без использования какого-либо интерфейса (т.е. веб-интерфейса, который автоматически обрабатывает шифрование).", ActionName = ActionNames.STORE_TRUE });
				parser.AddArgument(new Argument("-p", "--packager") { HelpText = "Запуск OctoBot Tentacles Manager. Примеры: -p install all для установки всех пакетов tentacles и -p install [tentacle] для установки определенного tentacle. Tentacles Manager позволяет устанавливать, обновлять, удалять и сбрасывать tentacles. Вы можете указать ветви github с помощью branch = параметр. Вы также можете пропустить ввод подтверждения установки, добавив принудительный параметр. Используйте: -p help, чтобы получить справку Tentacle Manager.", ValueCount = new ValueCount("+") });
				parser.AddArgument(new Argument("-c", "--creator") { HelpText = "Запуск OctoBot Tentacles Creator. Примеры: -c Evaluator для создания нового определения tentacle. Использование: -c help для получения помощи Tentacle Creator.", ValueCount = new ValueCount("+") });
				parser.AddArgument(new Argument("-o", "--strategy_optimizer") { HelpText = "Запуск оптимизатора стратегий Octobot. Этот режим заставит октобота воспроизводить сценарии тестирования на исторических данных, расположенные в abstract_strategy_test.py с различными таймфреймами, определениями и рисками, используя режим торговли, заданный в config.json. Этот инструмент полезен для быстрого тестирования стратегии и автоматического поиска лучших совместимых настроек. Параметр - это название класса стратегии для тестирования. Пример: -o FullMixedStrategiesEvaluator Предупреждение: этот процесс может занять много времени.", ValueCount = new ValueCount("+") });

				var parseResult = parser.ParseArguments(args);

				StartCoreService(parseResult);
			}
			catch (Exception exc)
			{
				Debug.WriteLine(1);
			}

			Console.WriteLine("Hello World!");
		}
		private static void StartCoreService(ParseResult parserResult)
		{
			var coreService = Application.Resolve<ICoreService>();
			coreService.Start(parserResult);
			Console.ReadLine();
			coreService.Stop();
		}
	}
}
