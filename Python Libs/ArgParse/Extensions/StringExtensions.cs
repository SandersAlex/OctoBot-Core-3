
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ArgParse.Extensions
{
   internal static class StringExtensions
   {
      public static bool StartsWith(this string str, IEnumerable<string> compareStrings)
      {
         return compareStrings.Any(it => str.StartsWith(it, true, CultureInfo.InvariantCulture));
      }
   }
}