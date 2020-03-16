using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OctoBot
{
   public class DictionaryExchangeConverter : JsonConverter
   {
      /*public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         this.WriteValue(writer, value);
      }*/
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        => serializer.Serialize(writer, ((Dictionary<string, Exchange>)value).ToList());

      private void WriteValue(JsonWriter writer, object value)
      {
         var t = JToken.FromObject(value);
         switch (t.Type)
         {
            case JTokenType.Object:
               this.WriteObject(writer, value);
               break;
            case JTokenType.Array:
               this.WriteArray(writer, value);
               break;
            default:
               writer.WriteValue(value);
               break;
         }
      }

      private void WriteObject(JsonWriter writer, object value)
      {
         writer.WriteStartObject();

         if (value is IDictionary<string, Exchange>)
         {
            var obj = value as IDictionary<string, Exchange>;
            foreach (var kvp in obj)
            {
               writer.WritePropertyName(kvp.Key);
               this.WriteValue(writer, kvp.Value);
            }
         }
         else if (value is Exchange)
         {
            var obj = value as Exchange;
            Debug.WriteLine(1);
         }
         writer.WriteEndObject();
      }

      private void WriteArray(JsonWriter writer, object value)
      {
         writer.WriteStartArray();
         var array = value as IEnumerable<object>;
         foreach (var o in array)
         {
            this.WriteValue(writer, o);
         }
         writer.WriteEndArray();
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Dictionary<string, Exchange> dict = new Dictionary<string, Exchange>();

         var jsonObject = JObject.Load(reader);
         serializer.Populate(jsonObject.CreateReader(), dict);

         return dict;

         //return ReadValue(reader, objectType, existingValue, serializer);
      }

      private object ReadValue(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         while (reader.TokenType == JsonToken.Comment)
         {
            if (!reader.Read()) throw new JsonSerializationException("Unexpected Token when converting IDictionary<string, object>");
         }

         switch (reader.TokenType)
         {
            case JsonToken.StartObject:
               return ReadObject(reader, objectType, existingValue, serializer);
            case JsonToken.StartArray:
               return this.ReadArray(reader);
            case JsonToken.Integer:
            case JsonToken.Float:
            case JsonToken.String:
            case JsonToken.Boolean:
            case JsonToken.Undefined:
            case JsonToken.Null:
            case JsonToken.Date:
            case JsonToken.Bytes:
               return reader.Value;
            default:
               throw new JsonSerializationException
                   (string.Format("Unexpected token when converting IDictionary<string, object>: {0}", reader.TokenType));
         }
      }

      private object ReadArray(JsonReader reader)
      {
         IList<object> list = new List<object>();

         while (reader.Read())
         {
            switch (reader.TokenType)
            {
               case JsonToken.Comment:
                  break;
               default:
                  /*var v = ReadValue(reader);

                  list.Add(v);*/
                  break;
               case JsonToken.EndArray:
                  return list;
            }
         }

         throw new JsonSerializationException("Unexpected end when reading IDictionary<string, object>");
      }

      private object ReadObject(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         JObject obj1 = JObject.Load(reader);
         JProperty prop = obj1.Properties().First();

         var obj = new Dictionary<string, Exchange>();

         while (reader.Read())
         {
            switch (reader.TokenType)
            {
               case JsonToken.PropertyName:
                  var propertyName = reader.Value.ToString();

                  if (!reader.Read())
                  {
                     throw new JsonSerializationException("Unexpected end when reading IDictionary<string, object>");
                  }

                  var v = ReadValue(reader, objectType, existingValue, serializer);

                  obj[propertyName] = (Exchange)v;
                  break;
               case JsonToken.Comment:
                  break;
               case JsonToken.EndObject:
                  return obj;
               case JsonToken.Integer:
               case JsonToken.Float:
               case JsonToken.String:
               case JsonToken.Boolean:
               case JsonToken.Undefined:
               case JsonToken.Null:
               case JsonToken.Date:
               case JsonToken.Bytes:
                  var b = reader.Value;
                  break;
               default:
                  var c = reader.Value;
                  break;
            }
         }

         throw new JsonSerializationException("Unexpected end when reading IDictionary<string, object>");
      }

      public override bool CanConvert(Type objectType)
      {
         //var a = GetDictionaryKeyValueTypes(objectType).Count() == 1;

         return typeof(IDictionary<string, Exchange>).IsAssignableFrom(objectType);
      }
      private IEnumerable<KeyValuePair<Type, Type>> GetDictionaryKeyValueTypes(Type type)
      {
         foreach (Type intType in GetInterfacesAndSelf(type))
         {
            if (intType.GetTypeInfo().IsGenericType
                && intType.GetGenericTypeDefinition() == typeof(IDictionary<,>))
            {
               var args = intType.GetTypeInfo().GenericTypeArguments;
               // вроде бы именно GenericTypeArguments, а не Parameters
               if (args.Length == 2)
                  yield return new KeyValuePair<Type, Type>(args[0], args[1]);
            }
         }
      }
      private IEnumerable<Type> GetInterfacesAndSelf(Type type)
      {
         if (type == null)
            throw new ArgumentNullException();
         if (type.GetTypeInfo().IsInterface)
            return new[] { type }.Concat(type.GetTypeInfo().ImplementedInterfaces);
         else
            return type.GetTypeInfo().ImplementedInterfaces;
      }
   }
}