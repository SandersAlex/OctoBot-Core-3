using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OctoBot.Config;
using OctoBot.Utils;

namespace OctoBot.Tools
{
	public static class ExternalResourcesManager
	{
		public static string GetExternalResource(string resourceKey, bool catchException = false, string defaultResponse = "")
		{
			string externalResourceUrl = $"{ConfigVars.ASSETS_BRANCH}/{ConfigVars.EXTERNAL_RESOURCES_FILE}";

			string externalResources = JObject.Parse(FileUtilities.GetFileContents(externalResourceUrl))[resourceKey].ToString();

			return externalResources;
		}
	}
}