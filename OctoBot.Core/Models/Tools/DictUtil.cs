using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json.Linq;
using Serilog.Core;

namespace OctoBot.Tools
{
	public static class DictUtil
	{
		public static void FindNestedValue(object dict, object field)
		{
			Debug.WriteLine(1);
		}
		public static void GetValueOrDefault(object dictionary, object key, object defaultObj = null, bool strict = false)
		{
			Debug.WriteLine(1);
		}
		public static void CheckAndMergeValuesFromReference(ConfigJson currentDict, ConfigJson referenceDict, List<string> exceptionList, Logger logger = null)
		{
			//This is the comparison class
			CompareLogic compareLogic = new CompareLogic();

			ComparisonResult result = compareLogic.Compare(currentDict, referenceDict);

			//These will be different, write out the differences
			if (!result.AreEqual)
			{
				Debug.WriteLine(result.DifferencesString);
			}
				

			/*foreach (PropertyInfo pi in rePropInfos)
			{
				string key = elem.Key;
				JToken val = elem.Value;

				if (currentDict.ContainsKey(key) == false)
				{
					currentDict.Add(new JProperty(key, val));

					if (logger != null) logger.Warning($"В конфигурации пропущен ключ{key} in configuration, было добавлено значение по умолчанию: {val}");
				}
				else if (val.Type == JTokenType.Object && exceptionList.Contains(key) == false)
				{
					CheckAndMergeValuesFromReference((JObject)currentDict[key], (JObject)val, exceptionList, logger);
				}
			}*/
		}
	}
}