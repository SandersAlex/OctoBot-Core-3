using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OctoBot
{
   public class DictionaryJsonParamConverter<T> : JsonConverter
   {
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
          => serializer.Serialize(writer, ((Dictionary<string, T>)value).ToList());

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Dictionary<string, T> dict = new Dictionary<string, T>();

         var jsonObject = JObject.Load(reader);
         serializer.Populate(jsonObject.CreateReader(), dict);

         return dict;
      }

      public override bool CanConvert(Type objectType)
      {
         return objectType.GetInterfaces().Count(i => HasGenericTypeDefinition(i, typeof(IDictionary<string,T>))) > 0;
      }
      private static bool HasGenericTypeDefinition(Type objectType, Type typeDefinition)
      {
         return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeDefinition;
      }
   }
}
