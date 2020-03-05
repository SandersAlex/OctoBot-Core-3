using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace OctoBot.Core
{
	internal class ConfigProvider : IConfigProvider
	{
		private const string ROOT_CONFIG_DIR = "config";
		private const string PATHS_CONFIG_PATH = "config_paths.json";
		private const string PATHS_SECTION_NAME = "Paths";
		private IConfigurationSection paths;

		public ConfigProvider()
		{
			IConfigurationRoot pathsConfig = GetConfig(PATHS_CONFIG_PATH, changedPathsConfig =>
			{
				paths = changedPathsConfig.GetSection(PATHS_SECTION_NAME);
			});
			paths = pathsConfig.GetSection(PATHS_SECTION_NAME);
		}

		public IConfigurationSection GetSection(string sectionName, Action<IConfigurationSection> onChange = null)
		{
			string configPath = paths.GetValue<string>(sectionName);
			IConfigurationRoot configRoot = GetConfig(configPath, changedConfigRoot =>
			{
				onChange?.Invoke(changedConfigRoot.GetSection(sectionName));
			});
			return configRoot.GetSection(sectionName);
		}
		public T GetSection<T>(string sectionName, Action<T> onChange = null)
		{
			IConfigurationSection configSection = GetSection(sectionName, changedConfigSection =>
			{
				onChange?.Invoke(changedConfigSection.Get<T>());
			});
			return configSection.Get<T>();
		}
		private IConfigurationRoot GetConfig(string configPath, Action<IConfigurationRoot> onChange)
		{
			var fullConfigPath = Path.Combine(Directory.GetCurrentDirectory(), ROOT_CONFIG_DIR);

			var configBuilder = new ConfigurationBuilder()
				  .SetBasePath(fullConfigPath)
				  .AddJsonFile(configPath, optional: false, reloadOnChange: true)
				  .AddEnvironmentVariables();

			var configRoot = configBuilder.Build();
			ChangeToken.OnChange(configRoot.GetReloadToken, () => onChange(configRoot));
			return configRoot;
		}
	}
}