using System;
using System.Collections.Generic;
using System.Text;

namespace OctoBot.Tentacles.Manager
{
	public static class TentaclesManagerVars
	{
      public static string VERSION = "1.0.13";
      public static string PROJECT_NAME = "OctoBot-Tentacles-Manager";
      public static string OCTOBOT_NAME = "OctoBot";

      public static string OCTOBOT_ADV_MNG_IMPORT_CHANGE_VERSION = "0.3.4";

      public static int LOG_LEVEL = 20;

      // github
      public static string GITHUB = "github";
      public static string GITHUB_RAW_CONTENT_URL = "https://raw.githubusercontent.com";
      public static string GITHUB_API_CONTENT_URL = "https://api.github.com";
      public static string GITHUB_BASE_URL = "https://github.com";
      public static string GITHUB_ORGANISATION = "Drakkar-Software";
      public static string GITHUB_REPOSITORY = $"{GITHUB_ORGANISATION}/{OCTOBOT_NAME}";
      public static string GITHUB_URL = $"{GITHUB_BASE_URL}/{GITHUB_REPOSITORY}";

      public static string CONFIG_DEBUG_OPTION = "DEV-MODE";

      // Tentacles (packages)
      public static string PYTHON_INIT_FILE = "__init__.py";
      public static string CONFIG_EVALUATOR_FILE = "evaluator_config.json";
      public static string CONFIG_TRADING_FILE = "trading_config.json";
      public static string TENTACLES_PATH = "Tentacles";
      public static string TENTACLES_EVALUATOR_PATH = "Evaluator";
      public static string TENTACLES_TRADING_PATH = "Trading";
      public static string CONFIG_EVALUATOR_FILE_PATH = $"{TENTACLES_PATH}/{TENTACLES_EVALUATOR_PATH}/{CONFIG_EVALUATOR_FILE}";
      public static string CONFIG_TRADING_FILE_PATH = $"{TENTACLES_PATH}/{TENTACLES_TRADING_PATH}/{CONFIG_TRADING_FILE}";
      public static string CONFIG_DEFAULT_EVALUATOR_FILE = "config/default_evaluator_config.json";
      public static string CONFIG_DEFAULT_TRADING_FILE = "config/default_trading_config.json";
      public static string TENTACLES_TEST_PATH = "Tests";
      public static string TENTACLES_EVALUATOR_REALTIME_PATH = "RealTime";
      public static string TENTACLES_EVALUATOR_TA_PATH = "TA";
      public static string TENTACLES_EVALUATOR_SOCIAL_PATH = "Social";
      public static string TENTACLES_EVALUATOR_STRATEGIES_PATH = "Strategies";
      public static string TENTACLES_EVALUATOR_UTIL_PATH = "Util";
      public static string TENTACLES_TRADING_MODE_PATH = "Mode";
      public static string TENTACLES_PYTHON_INIT_CONTENT = "from .Default import *\nfrom .Advanced import *\n";
      public static string TENTACLES_PUBLIC_REPOSITORY = $"{GITHUB_ORGANISATION}/{OCTOBOT_NAME}-Tentacles";
      public static string TENTACLES_PUBLIC_LIST = "tentacles_list.json";
      public static string TENTACLES_DEFAULT_BRANCH = "master";
      public static string EVALUATOR_DEFAULT_FOLDER = "Default";
      public static string EVALUATOR_ADVANCED_FOLDER = "Advanced";
      public static List<string> TENTACLES_INSTALL_FOLDERS = new List<string>() { EVALUATOR_DEFAULT_FOLDER, EVALUATOR_ADVANCED_FOLDER };
      public static string EVALUATOR_CONFIG_FOLDER = "Config";
      public static string EVALUATOR_RESOURCE_FOLDER = "Resources";
      public static string CONFIG_TENTACLES_KEY = "tentacles-packages";
      public static string TENTACLE_PACKAGE_DESCRIPTION = "package_description";
      public static string TENTACLE_PACKAGE_DESCRIPTION_LOCALISATION = "localisation";
      public static string TENTACLE_PACKAGE_NAME = "name";
      public static string TENTACLE_DESCRIPTION_IS_URL = "is_url";
      public static string TENTACLE_MODULE_TESTS = "tests";
      public static string TENTACLE_MODULE_DESCRIPTION = "$tentacle_description";
      public static string TENTACLE_MODULE_REQUIREMENTS = "requirements";
      public static string TENTACLE_MODULE_REQUIREMENT_WITH_VERSION = "requirement_with_version";
      public static string TENTACLE_MODULE_LIST_SEPARATOR = ",";
      public static string TENTACLE_MODULE_REQUIREMENT_VERSION_SEPARATOR = "==";
      public static string TENTACLE_MODULE_NAME = "name";
      public static string TENTACLE_MODULE_TYPE = "type";
      public static string TENTACLE_MODULE_SUBTYPE = "subtype";
      public static string TENTACLE_MODULE_VERSION = "version";
      public static string TENTACLE_MODULE_DEV = "developing";
      public static string TENTACLE_PACKAGE = "package_name";
      public static string TENTACLE_MODULE_CONFIG_FILES = "config_files";
      public static string TENTACLE_MODULE_CONFIG_SCHEMA_FILES = "config_schema_files";
      public static string TENTACLE_MODULE_RESOURCE_FILES = "resource_files";
      public static string TENTACLE_CREATOR_PATH = "tentacle_creator";
      public static string TENTACLE_TEMPLATE_DESCRIPTION = "description";
      public static string TENTACLE_TEMPLATE_PATH = "templates";
      public static string TENTACLE_TEMPLATE_PRE_EXT = "_tentacle";
      public static string TENTACLE_CONFIG_TEMPLATE_PRE_EXT = "_config";
      public static string TENTACLE_TEMPLATE_EXT = ".template";
      public static string TENTACLE_CURRENT_MINIMUM_DEFAULT_TENTACLES_VERSION = "1.1.0";

      public static Dictionary<string, string> TENTACLE_SONS = new Dictionary<string, string>()
      {
         { "Social", TENTACLES_EVALUATOR_SOCIAL_PATH },
         { "RealTime", TENTACLES_EVALUATOR_REALTIME_PATH },
         { "Util", TENTACLES_EVALUATOR_UTIL_PATH },
         { "TA", TENTACLES_EVALUATOR_TA_PATH },
         { "Strategies", TENTACLES_EVALUATOR_STRATEGIES_PATH },
         { "Mode", TENTACLES_TRADING_MODE_PATH }
      };

      public static Dictionary<string, string> TENTACLE_PARENTS = new Dictionary<string, string>()
      {
         { "Evaluator", TENTACLES_EVALUATOR_PATH },
         { "Trading", TENTACLES_TRADING_PATH }
      };

      public static List<Dictionary<string, string>> TENTACLE_TYPES = new List<Dictionary<string, string>>() { TENTACLE_PARENTS, TENTACLE_SONS };

      // other
      public static string CONFIG_FILE_EXT = ".json";

      public enum TentacleManagerActions
      {
         INSTALL = 1,
         UNINSTALL = 2,
         UPDATE = 3
      }
	}
}