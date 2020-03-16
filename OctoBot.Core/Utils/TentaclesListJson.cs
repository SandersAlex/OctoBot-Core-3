using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OctoBot
{
   public partial class TentaclesListJson
   {
      public Dictionary<string, TentacleModule> ListPuneHedgehog { get; set; } = new Dictionary<string, TentacleModule>();

      [JsonProperty("instant_fluctuations_evaluator")]
      public TentacleModule InstantFluctuationsEvaluator { get; set; }

      [JsonProperty("in_development_real_time_evaluators")]
      public TentacleModule InDevelopmentRealTimeEvaluators { get; set; }

      [JsonProperty("price_refresher_evaluator")]
      public TentacleModule PriceRefresherEvaluator { get; set; }

      [JsonProperty("signal_evaluators")]
      public TentacleModule SignalEvaluators { get; set; }

      [JsonProperty("forum_evaluator")]
      public TentacleModule ForumEvaluator { get; set; }

      [JsonProperty("in_development_social_evaluators")]
      public TentacleModule InDevelopmentSocialEvaluators { get; set; }

      [JsonProperty("news_evaluator")]
      public TentacleModule NewsEvaluator { get; set; }

      [JsonProperty("stats_evaluator")]
      public TentacleModule StatsEvaluator { get; set; }

      [JsonProperty("dip_analyser_strategy_evaluator")]
      public TentacleModule DipAnalyserStrategyEvaluator { get; set; }

      [JsonProperty("high_frequency_strategy_evaluator")]
      public TentacleModule HighFrequencyStrategyEvaluator { get; set; }

      [JsonProperty("market_making_startegy_evaluator")]
      public TentacleModule MarketMakingStartegyEvaluator { get; set; }

      [JsonProperty("market_stability_strategy_evaluator")]
      public TentacleModule MarketStabilityStrategyEvaluator { get; set; }

      [JsonProperty("mixed_strategies_evaluator")]
      public TentacleModule MixedStrategiesEvaluator { get; set; }

      [JsonProperty("move_signals_strategy_evaluator")]
      public TentacleModule MoveSignalsStrategyEvaluator { get; set; }

      [JsonProperty("staggered_orders_strategy_evaluator")]
      public TentacleModule StaggeredOrdersStrategyEvaluator { get; set; }

      [JsonProperty("in_development_TA_evaluators")]
      public TentacleModule InDevelopmentTaEvaluators { get; set; }

      [JsonProperty("momentum_evaluator")]
      public TentacleModule MomentumEvaluator { get; set; }

      [JsonProperty("trend_evaluator")]
      public TentacleModule TrendEvaluator { get; set; }

      [JsonProperty("volatility_evaluator")]
      public TentacleModule VolatilityEvaluator { get; set; }

      [JsonProperty("overall_state_analysis")]
      public TentacleModule OverallStateAnalysis { get; set; }

      [JsonProperty("pattern_analysis")]
      public TentacleModule PatternAnalysis { get; set; }

      [JsonProperty("statistics_analysis")]
      public TentacleModule StatisticsAnalysis { get; set; }

      [JsonProperty("text_analysis")]
      public TentacleModule TextAnalysis { get; set; }

      [JsonProperty("trend_analysis")]
      public TentacleModule TrendAnalysis { get; set; }

      [JsonProperty("daily_trading_mode")]
      public TentacleModule DailyTradingMode { get; set; }

      [JsonProperty("dip_analyser_trading_mode")]
      public TentacleModule DipAnalyserTradingMode { get; set; }

      [JsonProperty("high_frequency_mode")]
      public TentacleModule HighFrequencyMode { get; set; }

      [JsonProperty("hybrid_trading_mode")]
      public TentacleModule HybridTradingMode { get; set; }

      [JsonProperty("investor_mode")]
      public TentacleModule InvestorMode { get; set; }

      [JsonProperty("market_maker_trading_mode")]
      public TentacleModule MarketMakerTradingMode { get; set; }

      [JsonProperty("objective_mode")]
      public TentacleModule ObjectiveMode { get; set; }

      [JsonProperty("opportunity_mode")]
      public TentacleModule OpportunityMode { get; set; }

      [JsonProperty("safe_profit_mode")]
      public TentacleModule SafeProfitMode { get; set; }

      [JsonProperty("signal_trading_mode")]
      public TentacleModule SignalTradingMode { get; set; }

      [JsonProperty("simple_trading_mode")]
      public TentacleModule SimpleTradingMode { get; set; }

      [JsonProperty("staggered_orders_trading_mode")]
      public TentacleModule StaggeredOrdersTradingMode { get; set; }

      [JsonProperty("package_description")]
      public PackageDescription PackageDescription { get; set; }
   }

   public partial class TentacleModule
   {
      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("type")]
      public TypeEnum Type { get; set; }

      [JsonProperty("subtype")]
      public string Subtype { get; set; }

      [JsonProperty("version")]
      public string Version { get; set; }

      [JsonProperty("requirements", NullValueHandling = NullValueHandling.Ignore)]
      public List<string> Requirements { get; set; }

      [JsonProperty("config_files", NullValueHandling = NullValueHandling.Ignore)]
      public List<string> ConfigFiles { get; set; }

      [JsonProperty("config_schema_files", NullValueHandling = NullValueHandling.Ignore)]
      public List<string> ConfigSchemaFiles { get; set; }

      [JsonProperty("tests", NullValueHandling = NullValueHandling.Ignore)]
      public List<string> Tests { get; set; }

      [JsonProperty("developing", NullValueHandling = NullValueHandling.Ignore)]
      public bool? Developing { get; set; }
      [JsonProperty("resource_files", NullValueHandling = NullValueHandling.Ignore)]
      public object ResourceFiles { get; set; }
      [JsonProperty("package_name", NullValueHandling = NullValueHandling.Ignore)]
      public string PackageName { get; set; }
   }

   public partial class PackageDescription
   {
      [JsonProperty("localisation")]
      public Uri Localisation { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("is_url")]
      public bool IsUrl { get; set; }
   }

   public enum TypeEnum { Evaluator, Trading };

   public partial class TentaclesListJson
   {
      public static TentaclesListJson FromJson(string json) => JsonConvert.DeserializeObject<TentaclesListJson>(json, TentaclesListJsonConverter.Settings);
   }

   public static class TentaclesListJsonSerialize
   {
      public static string ToJson(this TentaclesListJson self) => JsonConvert.SerializeObject(self, TentaclesListJsonConverter.Settings);
   }

   internal static class TentaclesListJsonConverter
   {
      public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
      {
         MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
         DateParseHandling = DateParseHandling.None,
         Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
            },
      };
   }

   internal class TypeEnumConverter : JsonConverter
   {
      public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

      public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
      {
         if (reader.TokenType == JsonToken.Null) return null;
         var value = serializer.Deserialize<string>(reader);
         switch (value)
         {
            case "Evaluator":
               return TypeEnum.Evaluator;
            case "Trading":
               return TypeEnum.Trading;
         }
         throw new Exception("Cannot unmarshal type TypeEnum");
      }

      public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
      {
         if (untypedValue == null)
         {
            serializer.Serialize(writer, null);
            return;
         }
         var value = (TypeEnum)untypedValue;
         switch (value)
         {
            case TypeEnum.Evaluator:
               serializer.Serialize(writer, "Evaluator");
               return;
            case TypeEnum.Trading:
               serializer.Serialize(writer, "Trading");
               return;
         }
         throw new Exception("Cannot marshal type TypeEnum");
      }

      public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
   }
}