using System;
using System.Collections.Generic;
using System.Text;

namespace OctoBot.Config
{
   public class ConfigVars
   {
      public static string PROJECT_NAME = "OctoBot";
      public static string SHORT_VERSION = "0.3.8"; // major.minor.revision
      public static string PATCH_VERSION = ""; // patch : pX
      public static string VERSION_DEV_PHASE = ""; // alpha : a / beta : b / release candidate : rc
      public static string VERSION_PHASE = ""; // XX
      public static string VERSION = $"{SHORT_VERSION}{VERSION_DEV_PHASE}{VERSION_PHASE}";
      public static string LONG_VERSION = $"{SHORT_VERSION}{PATCH_VERSION}{VERSION_DEV_PHASE}{VERSION_PHASE}";

      // logs
      public static string LOG_DATABASE = "log_db";
      public static string LOG_NEW_ERRORS_COUNT = "log_new_errors_count";
      public static string BACKTESTING_NEW_ERRORS_COUNT = "log_backtesting_errors_count";
      public static int STORED_LOG_MIN_LEVEL = 30;
      public static string LOGS_FOLDER = "logs";

      // github
      public static string GITHUB = "github";
      public static string GITHUB_RAW_CONTENT_URL = "https://raw.githubusercontent.com";
      public static string GITHUB_API_CONTENT_URL = "https://api.github.com";
      public static string GITHUB_BASE_URL = "https://github.com";
      public static string GITHUB_ORGANISATION = "Drakkar-Software";
      public static string GITHUB_REPOSITORY = $"{GITHUB_ORGANISATION}/{PROJECT_NAME}";
      public static string GITHUB_URL = $"{GITHUB_BASE_URL}/{GITHUB_REPOSITORY}";
      public static string ASSETS_BRANCH = "assets";
      public static string OCTOBOT_BACKGROUND_IMAGE = "static/img/octobot.png";
      public static string OCTOBOT_ICON = "static/favicon.ico";
      public static string EXTERNAL_RESOURCES_FILE = "external_resources.json";
      public static string EXTERNAL_RESOURCE_CURRENT_USER_FORM = "current-user-feedback-form";
      public static string EXTERNAL_RESOURCE_PUBLIC_ANNOUNCEMENTS = "public-announcements";

      // git
      public static string GIT_ORIGIN = "origin";
      public static string ORIGIN_URL = $"{GITHUB_URL}.git";

      // terms of service
      public static string CONFIG_ACCEPTED_TERMS = "accepted_terms";

      // constants
      public static int MSECONDS_TO_SECONDS = 1000;
      public static int MINUTE_TO_SECONDS = 60;
      public static int HOURS_TO_SECONDS = MINUTE_TO_SECONDS * 60;
      public static int HOURS_TO_MSECONDS = MSECONDS_TO_SECONDS * MINUTE_TO_SECONDS * MINUTE_TO_SECONDS;
      public static int DAYS_TO_SECONDS = HOURS_TO_SECONDS * 24;

      public static string CONFIG_GLOBAL_UTILS = "global_utils";
      public static string CONFIG_ENABLED_OPTION = "enabled";
      public static string CONFIG_SYMBOL = "symbol";
      public static string CONFIG_WILDCARD = "*";
      public static string CONFIG_SAVE_EVALUATION = "SAVE_EVALUATIONS";
      public static string EVALUATION_SAVING_FILE_ENDING = "_evaluations.csv";
      public static string EVALUATION_SAVING_COLUMN_SEPARATOR = ";";
      public static string EVALUATION_SAVING_ROW_SEPARATOR = "\n";

      public static string BOT_TOOLS_BACKTESTING = "backtesting";
      public static string BOT_TOOLS_STRATEGY_OPTIMIZER = "strategy_optimizer";
      public static string BOT_TOOLS_RECORDER = "recorder";

      // metrics
      public static string CONFIG_METRICS = "metrics";
      public static string CONFIG_METRICS_BOT_ID = "metrics-bot-id";
      public static int TIMER_BEFORE_METRICS_REGISTRATION_SECONDS = 600;
      public static int TIMER_BETWEEN_METRICS_UPTIME_UPDATE = 3600 * 4;
      public static string METRICS_URL = "https://octobotmetrics.herokuapp.com/";
      public static string METRICS_ROUTE_GEN_BOT_ID = "gen-bot-id";
      public static string METRICS_ROUTE = "metrics";
      public static string METRICS_ROUTE_COMMUNITY = $"{METRICS_ROUTE}/community";
      public static string METRICS_ROUTE_UPTIME = $"{METRICS_ROUTE}/uptime";
      public static string METRICS_ROUTE_REGISTER = $"{METRICS_ROUTE}/register";
      public static int COMMUNITY_TOPS_COUNT = 1000;
      public static string PLATFORM_DATA_SEPARATOR = ":";

      // default values in config files and interfaces
      public static List<string> DEFAULT_CONFIG_VALUES = new List<string>() { "your-api-key-here", "your-api-secret-here", "your-api-password-here", "NOKEY", "Empty" };

      // Async settings
      public static int DEFAULT_FUTURE_TIMEOUT = 120;

      // Advanced
      public static string CONFIG_ADVANCED_CLASSES = "advanced_classes";
      public static string CONFIG_ADVANCED_INSTANCES = "advanced_instances";

      // Backtesting
      public static string CONFIG_BACKTESTING = "backtesting";
      public static string CONFIG_ANALYSIS_ENABLED_OPTION = "post_analysis_enabled";
      public static string CONFIG_BACKTESTING_DATA_FILES = "files";
      public static int CONFIG_BACKTESTING_OTHER_MARKETS_STARTING_PORTFOLIO = 10000;
      public static string BACKTESTING_DATA_OHLCV = "ohlcv";
      public static string BACKTESTING_DATA_TRADES = "trades";

      // Data collector
      public static string CONFIG_DATA_COLLECTOR = "data_collector";
      public static string CONFIG_DATA_COLLECTOR_ZIPLINE = "zipline";
      public static int DATA_COLLECTOR_REFRESHER_TIME = MINUTE_TO_SECONDS;
      public static string CONFIG_DATA_COLLECTOR_PATH = "backtesting/collector/data/";

      // Trading
      public static string CONFIG_EXCHANGES = "exchanges";
      public static string CONFIG_EXCHANGE_KEY = "api-key";
      public static string CONFIG_EXCHANGE_SECRET = "api-secret";
      public static string CONFIG_EXCHANGE_PASSWORD = "api-password";
      public static string CONFIG_EXCHANGE_WEB_SOCKET = "web-socket";
      public static int DEFAULT_REST_RETRY_COUNT = 3;
      public static string CONFIG_TRADING = "trading";
      public static string CONFIG_TRADING_TENTACLES = "trading-tentacles";
      public static string CONFIG_TRADER = "trader";
      public static string CONFIG_SIMULATOR = "trader-simulator";
      public static string CONFIG_STARTING_PORTFOLIO = "starting-portfolio";
      public static string CONFIG_TRADER_RISK = "risk";
      public static decimal CONFIG_TRADER_RISK_MIN = 0.05m;
      public static int CONFIG_TRADER_RISK_MAX = 1;
      public static int ORDER_REFRESHER_TIME = 15;
      public static int ORDER_REFRESHER_TIME_WS = 1;
      public static int UPDATER_MAX_SLEEPING_TIME = 2;
      public static int SIMULATOR_LAST_PRICES_TO_CHECK = 50;
      public static int ORDER_CREATION_LAST_TRADES_TO_USE = 10;
      public static string CONFIG_TRADER_REFERENCE_MARKET = "reference-market";
      public static string DEFAULT_REFERENCE_MARKET = "BTC";
      public static string MARKET_SEPARATOR = "/";
      public static int CURRENCY_DEFAULT_MAX_PRICE_DIGITS = 8;
      public static int EXCHANGE_ERROR_SLEEPING_TIME = 10;
      public static string[] CONFIG_EXCHANGE_ENCRYPTED_VALUES = new[] { CONFIG_EXCHANGE_KEY, CONFIG_EXCHANGE_SECRET, CONFIG_EXCHANGE_PASSWORD };

      // Trader persistence
      public static string HISTORY_EXCHANGE_KEY = "exchange";
      public static string SIMULATOR_INITIAL_STARTUP_PORTFOLIO = "simulator_initial_portfolio";
      public static string REAL_INITIAL_STARTUP_PORTFOLIO = "real_initial_portfolio";
      public static string SIMULATOR_CURRENT_PORTFOLIO = "simulator_current_portfolio";
      public static string SIMULATOR_INITIAL_STARTUP_PORTFOLIO_VALUE = "simulator_initial_portfolio_value";
      public static string REAL_INITIAL_STARTUP_PORTFOLIO_VALUE = "real_initial_portfolio_value";
      public static string WATCHED_MARKETS_INITIAL_STARTUP_VALUES = "initial_watched_markets_value";
      public static string REFERENCE_MARKET = "reference_market";
      public static string CURRENT_PORTFOLIO_STRING = "Current Portfolio :";
      public static string CONFIG_ENABLED_PERSISTENCE = "multi-session-profitability";


      // Exchanges
      public static string[] TESTED_EXCHANGES = new[] { "binance", "coinbasepro", "kucoin2" };
      public static string[] SIMULATOR_TESTED_EXCHANGES = new[] { "bitfinex", "bittrex", "coinbasepro", "kraken", "kucoin2", "poloniex", "cryptopia", "bitmex" };

      public static string CONFIG_SIMULATOR_FEES = "fees";
      public static string CONFIG_SIMULATOR_FEES_MAKER = "maker";
      public static string CONFIG_SIMULATOR_FEES_TAKER = "taker";
      public static string CONFIG_SIMULATOR_FEES_WITHDRAW = "withdraw";
      public static decimal CONFIG_DEFAULT_FEES = 0.1m;
      public static int CONFIG_DEFAULT_SIMULATOR_FEES = 0;

      public static string CONFIG_PORTFOLIO_INFO = "info";
      public static string CONFIG_PORTFOLIO_FREE = "free";
      public static string CONFIG_PORTFOLIO_USED = "used";
      public static string CONFIG_PORTFOLIO_TOTAL = "total";

      // Notification
      public static string CONFIG_NOTIFICATION_TYPE = "notification-type";
      public static string CONFIG_NOTIFICATION_INSTANCE = "notifier";
      public static string CONFIG_CATEGORY_NOTIFICATION = "notification";
      public static string PROJECT_NOTIFICATION = $"{PROJECT_NAME} {CONFIG_CATEGORY_NOTIFICATION}";
      public static string CONFIG_NOTIFICATION_GLOBAL_INFO = "global-info";
      public static string CONFIG_NOTIFICATION_PRICE_ALERTS = "price-alerts";
      public static string CONFIG_NOTIFICATION_TRADES = "trades";
      public static string NOTIFICATION_STARTING_MESSAGE = $"OctoBot v{LONG_VERSION} starting...";
      public static string NOTIFICATION_STOPPING_MESSAGE = $"OctoBot v{LONG_VERSION} stopping...";
      public static string REAL_TRADER_STR = "[Real Trader] ";
      public static string SIMULATOR_TRADER_STR = "[Simulator] ";
      public static string PAID_FEES_STR = "Paid fees";
      public static string DICT_BULLET_TOKEN_STR = "\n ";

      // DEBUG options
      public static string CONFIG_DEBUG_OPTION_PERF = "performance-analyser";
      public static int CONFIG_DEBUG_OPTION_PERF_REFRESH_TIME_MIN = 5;
      public static string CONFIG_DEBUG_OPTION = "DEV-MODE";
      public static bool FORCE_ASYNCIO_DEBUG_OPTION = false;

      // SERVICES
      public static string CONFIG_CATEGORY_SERVICES = "services";
      public static string CONFIG_SERVICE_INSTANCE = "service_instance";

      // telegram
      public static string CONFIG_TELEGRAM = "telegram";
      public static string CONFIG_TOKEN = "token";
      public static string CONFIG_TELEGRAM_CHANNEL = "telegram-channels";
      public static string MESSAGE_PARSE_MODE = "parse_mode";
      public static string CONFIG_TELEGRAM_ALL_CHANNEL = "*";
      public static string CONFIG_GROUP_MESSAGE = "group-message";
      public static string CONFIG_GROUP_MESSAGE_DESCRIPTION = "group-message-description";

      // web
      public static string CONFIG_WEB = "web";
      public static string CONFIG_WEB_IP = "ip";
      public static string CONFIG_WEB_PORT = "port";
      public static string DEFAULT_SERVER_IP = "0.0.0.0";
      public static int DEFAULT_SERVER_PORT = 5001;

      // twitter
      public static string CONFIG_TWITTERS_ACCOUNTS = "accounts";
      public static string CONFIG_TWITTERS_HASHTAGS = "hashtags";
      public static string CONFIG_TWITTER = "twitter";
      public static string CONFIG_TWITTER_API_INSTANCE = "twitter_api_instance";
      public static string CONFIG_TWEET = "tweet";
      public static string CONFIG_TWEET_DESCRIPTION = "tweet_description";

      // reddit
      public static string CONFIG_REDDIT = "reddit";
      public static string CONFIG_REDDIT_SUBREDDITS = "subreddits";
      public static string CONFIG_REDDIT_ENTRY = "entry";
      public static string CONFIG_REDDIT_ENTRY_WEIGHT = "entry_weight";

      // Evaluator
      public static string CONFIG_EVALUATOR = "evaluator";
      public static string CONFIG_FORCED_EVALUATOR = "forced_evaluator";
      public static string CONFIG_EVALUATOR_SOCIAL = "Social";
      public static string CONFIG_EVALUATOR_REALTIME = "RealTime";
      public static string CONFIG_EVALUATOR_TA = "TA";
      public static string CONFIG_EVALUATOR_STRATEGIES = "Strategies";
      public static string START_PENDING_EVAL_NOTE = "0"; // force exception
      public static int INIT_EVAL_NOTE = 0;
      public static int START_EVAL_PERTINENCE = 1;
      public static decimal MAX_TA_EVAL_TIME_SECONDS = 0.1m;
      public static int DEFAULT_WEBSOCKET_REAL_TIME_EVALUATOR_REFRESH_RATE_SECONDS = 1;
      public static int DEFAULT_REST_REAL_TIME_EVALUATOR_REFRESH_RATE_SECONDS = 60;
      public static string CONFIG_REFRESH_RATE = "refresh_rate_seconds";
      public static string CONFIG_TIME_FRAME = "time_frame";
      public static string CONFIG_FORCED_TIME_FRAME = "forced_time_frame";
      public static string CONFIG_FILE_EXT = ".json";
      public static string CONFIG_CRYPTO_CURRENCIES = "crypto-currencies";
      public static string CONFIG_CRYPTO_CURRENCY = "crypto-currency";
      public static string CONFIG_CRYPTO_PAIRS = "pairs";
      public static string CONFIG_CRYPTO_QUOTE = "quote";
      public static string CONFIG_CRYPTO_ADD = "add";
      public static string[] CONFIG_EVALUATORS_WILDCARD = new[] { CONFIG_WILDCARD };
      public static string EVALUATOR_ACTIVATION = "activation";
      public static Type EVALUATOR_EVAL_DEFAULT_TYPE = typeof(decimal);

      // Socials
      public static int SOCIAL_EVALUATOR_NOT_THREADED_UPDATE_RATE = 1;

      // Stats
      public static string STATS_EVALUATOR_HISTORY_TIME = "relevant_history_months";
      public static int STATS_EVALUATOR_MAX_HISTORY_TIME = 3;

      // Tools
      public static int DIVERGENCE_USED_VALUE = 30;
      public static string TOOLS_PATH = "tools";

      // Interfaces
      public static string CONFIG_INTERFACES = "interfaces";
      public static string CONFIG_INTERFACES_WEB = "web";
      public static string CONFIG_INTERFACES_TELEGRAM = "telegram";
      public static string CONFIG_USERNAMES_WHITELIST = "usernames-whitelist";

      // Tentacles (packages)
      public static string PYTHON_INIT_FILE = "__init__.py";
      public static string TENTACLES_PATH = "tentacles";
      public static string TENTACLES_EVALUATOR_PATH = "Evaluator";
      public static string TENTACLES_TRADING_PATH = "Trading";
      public static string CONFIG_TENTACLES_KEY = "tentacles-packages";
      public static string TENTACLE_PACKAGE_DESCRIPTION = "package_description";
      public static string TENTACLE_CONFIG_FOLDER = "config";
      public static string TENTACLES_TRADING_MODE_PATH = "Mode";
      public static string TENTACLES_DEFAULT_BRANCH = SHORT_VERSION;
      public static string TENTACLES_FORCE_CONFIRM_PARAM = "force";

      // Files
      public static string USER_FOLDER = "User";
      public static string CONFIG_FILE = "config.json";
      public static string TEMP_RESTORE_CONFIG_FILE = "temp_config.json";
      public static string CONFIG_EVALUATOR_FILE = "evaluator_config.json";
      public static string CONFIG_TRADING_FILE = "trading_config.json";
      public static string CONFIG_EVALUATOR_FILE_PATH = $"{TENTACLES_PATH}/{TENTACLES_EVALUATOR_PATH}/{CONFIG_EVALUATOR_FILE}";
      public static string CONFIG_TRADING_FILE_PATH = $"{TENTACLES_PATH}/{TENTACLES_TRADING_PATH}/{CONFIG_TRADING_FILE}";
      public static string CONFIG_FOLDER = "Config";
      public static string CONFIG_DEFAULT_EVALUATOR_FILE = $"{CONFIG_FOLDER}/default_evaluator_config.json";
      public static string CONFIG_DEFAULT_TRADING_FILE = $"{CONFIG_FOLDER}/default_trading_config.json";
      public static string SCHEMA = "schema";
      public static string CONFIG_FILE_SCHEMA = $"{CONFIG_FOLDER}/config_{SCHEMA}.json";
      public static string DEFAULT_CONFIG_FILE = $"{CONFIG_FOLDER}/default_config.json";
      public static string LOGGING_CONFIG_FILE = $"{CONFIG_FOLDER}/logging_config.json";
      public static string LOG_FILE = $"{LOGS_FOLDER}/{PROJECT_NAME}.log";
      public static string STATES_FOLDER = $"{LOGS_FOLDER}/states";
      public static string SIMULATOR_STATE_SAVE_FILE = $"{STATES_FOLDER}/trading_state_history.json";

      // Tentacle Config
      public static string STRATEGIES_REQUIRED_TIME_FRAME = "required_time_frames";
      public static string TRADING_MODE_REQUIRED_STRATEGIES = "required_strategies";
      public static string TRADING_MODE_REQUIRED_STRATEGIES_MIN_COUNT = "required_strategies_min_count";
      public static string STRATEGIES_REQUIRED_EVALUATORS = "required_evaluators";
      public static string TENTACLE_DEFAULT_CONFIG = "default_config";
      public static string TENTACLE_DEFAULT_FOLDER = "Default";
      public static string TENTACLE_UTIL_FOLDER = "Util";

      // Web interface
      public static string UPDATED_CONFIG_SEPARATOR = "_";
      public static string GLOBAL_CONFIG_KEY = "global_config";
      public static string EVALUATOR_CONFIG_KEY = "evaluator_config";
      public static string DEACTIVATE_OTHERS = "deactivate_others";
      public static string TRADING_CONFIG_KEY = "trading_config";
      public static string COIN_MARKET_CAP_CURRENCIES_LIST_URL = "https://api.coinmarketcap.com/v2/listings/";

      // Types
      public static Type CONFIG_DICT_TYPE = typeof(Dictionary<string, object>);

      public static class EvaluatorMatrixTypes
      {
         public static string TA = "TA";
         public static string SOCIAL = "SOCIAL";
         public static string REAL_TIME = "REAL_TIME";
         public static string STRATEGIES = "STRATEGIES";
      }

      public enum EvaluatorStates
      {
         SHORT = 1,
         VERY_SHORT = 2,
         LONG = 3,
         VERY_LONG = 4,
         NEUTRAL = 5
      }

      public static class PriceStrings
      {
         public static string STR_PRICE_TIME = "time";
         public static string STR_PRICE_CLOSE = "close";
         public static string STR_PRICE_OPEN = "open";
         public static string STR_PRICE_HIGH = "high";
         public static string STR_PRICE_LOW = "low";
         public static string STR_PRICE_VOL = "vol";
      }

      public static class OHLCVStrings
      {
         public static string TIMESTAMP = "timestamp";
         public static string OPEN = "open";
         public static string HIGH = "high";
         public static string LOW = "low";
         public static string CLOSE = "close";
         public static string VOLUME = "volume";
      }

      public enum PriceIndexes
      {
         IND_PRICE_TIME = 0,
         IND_PRICE_OPEN = 1,
         IND_PRICE_HIGH = 2,
         IND_PRICE_LOW = 3,
         IND_PRICE_CLOSE = 4,
         IND_PRICE_VOL = 5
      }

      public static class TimeFrames
      {
         public static string ONE_MINUTE = "1m";
         public static string THREE_MINUTES = "3m";
         public static string FIVE_MINUTES = "5m";
         public static string FIFTEEN_MINUTES = "15m";
         public static string THIRTY_MINUTES = "30m";
         public static string ONE_HOUR = "1h";
         public static string TWO_HOURS = "2h";
         public static string THREE_HOURS = "3h";
         public static string FOUR_HOURS = "4h";
         public static string SIX_HOURS = "6h";
         public static string HEIGHT_HOURS = "8h";
         public static string TWELVE_HOURS = "12h";
         public static string ONE_DAY = "1d";
         public static string THREE_DAYS = "3d";
         public static string ONE_WEEK = "1w";
         public static string ONE_MONTH = "1M";
      }

      public static string MIN_EVAL_TIME_FRAME = TimeFrames.FIVE_MINUTES;

      public static Dictionary<string, int> TimeFramesMinutes = new Dictionary<string, int>()
      {
         { TimeFrames.ONE_MINUTE, 1 },
         { TimeFrames.THREE_MINUTES, 3 },
         { TimeFrames.FIVE_MINUTES, 5 },
         { TimeFrames.FIFTEEN_MINUTES, 15 },
         { TimeFrames.THIRTY_MINUTES, 30 },
         { TimeFrames.ONE_HOUR, 60 },
         { TimeFrames.TWO_HOURS, 120 },
         { TimeFrames.THREE_HOURS, 180 },
         { TimeFrames.FOUR_HOURS, 240 },
         { TimeFrames.SIX_HOURS, 360 },
         { TimeFrames.HEIGHT_HOURS, 480 },
         { TimeFrames.TWELVE_HOURS, 720 },
         { TimeFrames.ONE_DAY, 1440 },
         { TimeFrames.THREE_DAYS, 4320 },
         { TimeFrames.ONE_WEEK, 10080 },
         { TimeFrames.ONE_MONTH, 43200 }
      };

      // ladder : 1-100
      public static Dictionary<string, int> TimeFramesRelevance = new Dictionary<string, int>()
      {
         { TimeFrames.ONE_MINUTE, 5 },
         { TimeFrames.THREE_MINUTES, 5 },
         { TimeFrames.FIVE_MINUTES, 5 },
         { TimeFrames.FIFTEEN_MINUTES, 15 },
         { TimeFrames.THIRTY_MINUTES, 30 },
         { TimeFrames.ONE_HOUR, 50 },
         { TimeFrames.TWO_HOURS, 50 },
         { TimeFrames.FOUR_HOURS, 50 },
         { TimeFrames.HEIGHT_HOURS, 30 },
         { TimeFrames.TWELVE_HOURS, 30 },
         { TimeFrames.ONE_DAY, 30 },
         { TimeFrames.THREE_DAYS, 15 },
         { TimeFrames.ONE_WEEK, 15 },
         { TimeFrames.ONE_MONTH, 5 }
      };

      public static string[] IMAGE_ENDINGS = new[] { "png", "jpg", "jpeg", "gif", "jfif", "tiff", "bmp", "ppm", "pgm", "pbm", "pnm", "webp", "hdr", "heif", "bat", "bpg", "svg", "cgm" };

      public static class TradeOrderSide
      {
         public static string BUY = "buy";
         public static string SELL = "sell";
      }

      public static class TradeOrderType
      {
         public static string LIMIT = "limit";
         public static string MARKET = "market";
         public static string STOP_LOSS = "stop_loss";
         public static string STOP_LOSS_LIMIT = "stop_loss_limit";
         public static string TAKE_PROFIT = "take_profit";
         public static string TAKE_PROFIT_LIMIT = "take_profit_limit";
         public static string LIMIT_MAKER = "limit_maker"; // LIMIT_MAKER is a limit order that is rejected if would be filled as taker
      }

      public static class OrderStatus
      {
         public static string FILLED = "closed";
         public static string OPEN = "open";
         public static string PARTIALLY_FILLED = "partially_filled";
         public static string CANCELED = "canceled";
         public static string CLOSED = "closed";
      }

      public enum TraderOrderType
      {
         BUY_MARKET = 1,
         BUY_LIMIT = 2,
         TAKE_PROFIT = 3,
         TAKE_PROFIT_LIMIT = 4,
         STOP_LOSS = 5,
         STOP_LOSS_LIMIT = 6,
         SELL_MARKET = 7,
         SELL_LIMIT = 8
      }

      public static class ExchangeConstantsTickersColumns
      {
         public static string SYMBOL = "symbol";
         public static string TIMESTAMP = "timestamp";
         public static string DATETIME = "datetime";
         public static string HIGH = "high";
         public static string LOW = "low";
         public static string BID = "bid";
         public static string BID_VOLUME = "bidVolume";
         public static string ASK = "ask";
         public static string ASK_VOLUME = "askVolume";
         public static string VWAP = "vwap";
         public static string OPEN = "open";
         public static string CLOSE = "close";
         public static string LAST = "last";
         public static string PREVIOUS_CLOSE = "previousClose";
         public static string CHANGE = "change";
         public static string PERCENTAGE = "percentage";
         public static string AVERAGE = "average";
         public static string BASE_VOLUME = "baseVolume";
         public static string QUOTE_VOLUME = "quoteVolume";
         public static string INFO = "info";
      }

      public static class ExchangeConstantsTickersInfoColumns
      {
         public static string SYMBOL = "symbol";
         public static string PRICE_CHANGE = "priceChange";
         public static string PRICE_CHANGE_PERCENT = "priceChangePercent";
         public static string WEIGHTED_AVERAGE_PRICE = "weightedAvgPrice";
         public static string PREVIOUS_CLOSE_PRICE = "prevClosePrice";
         public static string LAST_PRICE = "lastPrice";
         public static string LAST_QUANTITY = "lastQty";
         public static string BID_PRICE = "bidPrice";
         public static string BID_QUANTITY = "bidQty";
         public static string ASK_PRICE = "askPrice";
         public static string ASK_QUANTITY = "askQty";
         public static string OPEN_PRICE = "openPrice";
         public static string HIGH_PRICE = "highPrice";
         public static string LOW_PRICE = "lowPrice";
         public static string VOLUME = "volume";
         public static string QUOTE_VOLUME = "quoteVolume";
         public static string OPEN_TIME = "openTime";
         public static string CLOSE_TIME = "closeTime";
         public static string FIRST_ID = "firstId";
         public static string LAST_ID = "lastId";
         public static string COUNT = "count";
      }

      public static class ExchangeConstantsMarketStatusColumns
      {
         public static string SYMBOL = "symbol";
         public static string ID = "id";
         public static string CURRENCY = "base";
         public static string MARKET = "quote";
         public static string ACTIVE = "active";
         public static string PRECISION = "precision"; // number of decimal digits "after the dot"
         public static string PRECISION_PRICE = "price";
         public static string PRECISION_AMOUNT = "amount";
         public static string PRECISION_COST = "cost";
         public static string LIMITS = "limits"; // value limits when placing orders on this market
         public static string LIMITS_AMOUNT = "amount";
         public static string LIMITS_AMOUNT_MIN = "min"; // order amount should be > min
         public static string LIMITS_AMOUNT_MAX = "max"; // order amount should be < max
         public static string LIMITS_PRICE = "price"; // same min/max limits for the price of the order
         public static string LIMITS_PRICE_MIN = "min"; // order price should be > min
         public static string LIMITS_PRICE_MAX = "max"; // order price should be < max
         public static string LIMITS_COST = "cost"; // same limits for order cost = price * amount
         public static string LIMITS_COST_MIN = "min"; // order cost should be > min
         public static string LIMITS_COST_MAX = "max"; // order cost should be < max
         public static string INFO = "info";
      }

      public static class ExchangeConstantsMarketStatusInfoColumns
      {
         // binance specific
         public static string FILTERS = "filters";
         public static string FILTER_TYPE = "filterType";
         public static string PRICE_FILTER = "PRICE_FILTER";
         public static string LOT_SIZE = "LOT_SIZE";
         public static string MIN_PRICE = "minPrice";
         public static string MAX_PRICE = "maxPrice";
         public static string TICK_SIZE = "tickSize";
         public static string MIN_QTY = "minQty";
         public static string MAX_QTY = "maxQty";
      }

      public static class ExchangeConstantsOrderBookInfoColumns
      {
         public static string BIDS = "bids";
         public static string ASKS = "asks";
         public static string TIMESTAMP = "timestamp";
         public static string DATETIME = "datetime";
         public static string NONCE = "nonce";
      }

      public static class ExchangeConstantsOrderColumns
      {
         public static string INFO = "info";
         public static string ID = "id";
         public static string TIMESTAMP = "timestamp";
         public static string DATETIME = "datetime";
         public static string LAST_TRADE_TIMESTAMP = "lastTradeTimestamp";
         public static string SYMBOL = "symbol";
         public static string TYPE = "type";
         public static string SIDE = "side";
         public static string PRICE = "price";
         public static string AMOUNT = "amount";
         public static string COST = "cost";
         public static string AVERAGE = "average";
         public static string FILLED = "filled";
         public static string REMAINING = "remaining";
         public static string STATUS = "status";
         public static string FEE = "fee";
         public static string TRADES = "trades";
         public static string MAKER = "maker";
         public static string TAKER = "taker";
      }

      public static class ExchangeConstantsFeesColumns
      {
         public static string TYPE = "type";
         public static string CURRENCY = "currency";
         public static string RATE = "rate";
         public static string COST = "cost";
      }

      public static class ExchangeConstantsMarketPropertyColumns
      {
         public static string TAKER = "taker"; // trading
         public static string MAKER = "maker"; // trading
         public static string FEE = "fee"; // withdraw
      }

      public static class FeePropertyColumns
      {
         public static string TYPE = "type"; // taker of maker
         public static string CURRENCY = "currency"; // currency the fee is paid in
         public static string RATE = "rate"; // multiplier applied to compute fee
         public static string COST = "cost"; // fee amount
      }

      public static class PlatformsName
      {
         public static string WINDOWS = "nt";
         public static string LINUX = "posix";
         public static string MAC = "mac";
      }

      public enum BacktestingDataFormats
      {
         REGULAR_COLLECTOR_DATA = 0
      }

      public static class OctoBotTypes
      {
         public static string BINARY = "binary";
         public static string PYTHON = "python";
         public static string DOCKER = "docker";
      }

      public static class MetricsFields
      {
         public static string ID = "_id";
         public static string CURRENT_SESSION = "currentsession";
         public static string STARTED_AT = "startedat";
         public static string UP_TIME = "uptime";
         public static string SIMULATOR = "simulator";
         public static string TRADER = "trader";
         public static string EVAL_CONFIG = "evalconfig";
         public static string PAIRS = "pairs";
         public static string EXCHANGES = "exchanges";
         public static string NOTIFICATIONS = "notifications";
         public static string TYPE = "type";
         public static string PLATFORM = "platform";
         public static string REFERENCE_MARKET = "referencemarket";
         public static string PORTFOLIO_VALUE = "portfoliovalue";
         public static string PROFITABILITY = "profitability";
      }

      // web user settings
      public static string DEFAULT_DISPLAY_TIME_FRAME = TimeFrames.ONE_HOUR;
      public static string CONFIG_WATCHED_SYMBOLS = "watched_symbols";

      public static string OCTOBOT_KEY = "uVEw_JJe7uiXepaU_DR4T-ThkjZlDn8Pzl8hYPIv7w0=";
   }
}