using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OctoBot
{
   public partial class ConfigJson
   {
      [JsonProperty("DEV-MODE", NullValueHandling = NullValueHandling.Ignore)]
      public bool? DevMode { get; set; }
      [JsonProperty("backtesting")]
      public Backtesting Backtesting { get; set; }
      [JsonProperty("tentacles-packages")]
      public List<string> TentaclesPackages { get; set; }

      [JsonProperty("crypto-currencies")]
      public CryptoCurrencies CryptoCurrencies { get; set; }

      [JsonProperty("exchanges"), JsonConverter(typeof(DictionaryExchangeConverter))]
      public Dictionary<string, Exchange> Exchanges { get; set; }

      [JsonProperty("services")]
      public Services Services { get; set; }

      [JsonProperty("notification")]
      public Notification Notification { get; set; }

      [JsonProperty("trading")]
      public Trading Trading { get; set; }

      [JsonProperty("trader")]
      public Trader Trader { get; set; }

      [JsonProperty("trader-simulator")]
      public TraderSimulator TraderSimulator { get; set; }

      [JsonProperty("accepted_terms")]
      public bool AcceptedTerms { get; set; }
   }

   public partial class Backtesting
   {
      [JsonProperty("files")]
      public List<object> Files { get; set; }
   }

   public partial class CryptoCurrencies
   {
      [JsonProperty("Bitcoin")]
      public Bitcoin Bitcoin { get; set; }
   }

   public partial class Bitcoin
   {
      [JsonProperty("pairs")]
      public List<string> Pairs { get; set; }
   }

   public partial class Exchange
   {
      [JsonProperty("api-key")]
      public string ApiKey { get; set; }

      [JsonProperty("api-secret")]
      public string ApiSecret { get; set; }
      [JsonProperty("api-password")]
      public string ApiPassword { get; set; }
   }

   public partial class Notification
   {
      [JsonProperty("global-info")]
      public bool GlobalInfo { get; set; }

      [JsonProperty("price-alerts")]
      public bool PriceAlerts { get; set; }

      [JsonProperty("trades")]
      public bool Trades { get; set; }

      [JsonProperty("notification-type")]
      public List<object> NotificationType { get; set; }
   }

   public partial class Services
   {
   }

   public partial class Trader
   {
      [JsonProperty("enabled")]
      public bool Enabled { get; set; }
   }

   public partial class TraderSimulator
   {
      [JsonProperty("enabled")]
      public bool Enabled { get; set; }

      [JsonProperty("fees")]
      public Fees Fees { get; set; }

      [JsonProperty("starting-portfolio")]
      public Dictionary<string, long> StartingPortfolio { get; set; }
   }

   public partial class Fees
   {
      [JsonProperty("maker")]
      public decimal Maker { get; set; }

      [JsonProperty("taker")]
      public decimal Taker { get; set; }
   }

   public partial class Trading
   {
      [JsonProperty("multi-session-profitability")]
      public bool MultiSessionProfitability { get; set; }

      [JsonProperty("reference-market")]
      public string ReferenceMarket { get; set; }

      [JsonProperty("risk")]
      public decimal Risk { get; set; }
   }

   public partial class ConfigJson
   {
      public static ConfigJson FromJson(string json) => JsonConvert.DeserializeObject<ConfigJson>(json, ConfigJsonConverter.Settings);
   }

   public static class ConfigJsonSerialize
   {
      public static string ToJson(this ConfigJson self) => JsonConvert.SerializeObject(self, ConfigJsonConverter.Settings);
   }

   internal static class ConfigJsonConverter
   {
      public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
      {
         MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
         DateParseHandling = DateParseHandling.None,
         Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
                new DictionaryExchangeConverter()
            },
      };
   }
}