using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace OctoBot.Core
{
	public interface IConfigProvider
	{
		IConfigurationSection GetSection(string sectionName, Action<IConfigurationSection> onChange = null);
		T GetSection<T>(string sectionName, Action<T> onChange = null);
	}
}