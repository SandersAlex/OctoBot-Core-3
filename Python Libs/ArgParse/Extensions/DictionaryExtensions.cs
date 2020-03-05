using System;
using System.Collections.Generic;
using System.Text;

namespace ArgParse.Extensions
{
   internal static class DictionaryExtensions
   {
      public static TValue SafeGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,
          TValue defaultValue = default(TValue))
      {
         if (dictionary == null || Equals(key, null)) return defaultValue;
         TValue ret;
         return dictionary.TryGetValue(key, out ret)
             ? ret
             : defaultValue;
      }
   }
}