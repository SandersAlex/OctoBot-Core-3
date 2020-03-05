using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgParse
{
   /// <summary>
   /// Describe count arguments
   /// </summary>
   public class ValueCount : IEquatable<ValueCount>
   {
      private static readonly Lazy<ValueCount> zeroLazy = new Lazy<ValueCount>(() => new ValueCount(0));
      private static readonly Lazy<ValueCount> optionalLazy = new Lazy<ValueCount>(() => new ValueCount(0, 1));

      public ValueCount() : this(0, 1)
      {
      }

      public ValueCount(uint? n) : this(n, n)
      {
      }

      public ValueCount(uint? min, uint? max)
      {
         Min = min;
         Max = max;
         Normalize();
         OriginalString = GetRegexString();
      }

      public ValueCount(int n) : this(n, n)
      {
      }

      public ValueCount(int min, int max)
      {
         Min = ToNullable(min);
         Max = ToNullable(max);
         Normalize();
         OriginalString = GetRegexString();
      }

      public ValueCount(string countString)
      {
         OriginalString = countString;
         switch (countString)
         {
            case "?":
               Min = 0;
               Max = 1;
               break;
            case "*":
               Min = 0;
               break;
            case "+":
               Min = 1;
               break;
         }
         IList<uint?> values;
         try
         {
            values =
                (countString ?? "").TrimStart('{').TrimEnd('}').Split(new[] { "," }, StringSplitOptions.None)
                    .Select(it => it.Trim())
                    .Select(it => string.IsNullOrEmpty(it) ? (uint?)null : uint.Parse(it))
                    .ToList();
         }
         catch
         {
            values = new List<uint?>();
         }
         if (values.Count == 1)
            Min = Max = values[0];
         else if (values.Count > 1)
         {
            Min = values[0];
            Max = values[1];
         }
         Normalize();
      }

      public bool IsZeroOrMore
      {
         get { return Min == 0 && (!Max.HasValue || Max > 0); }
      }

      public uint? Max { get; private set; }

      public uint? Min { get; private set; }

      public static ValueCount Optional
      {
         get { return optionalLazy.Value; }
      }

      public string OriginalString { get; private set; }

      public static ValueCount Zero
      {
         get { return zeroLazy.Value; }
      }

      public bool Equals(ValueCount other)
      {
         return other != null && Min == other.Min && Max == other.Max;
      }

      public override int GetHashCode()
      {
         unchecked
         {
            return (Max.GetHashCode() * 397) ^ Min.GetHashCode();
         }
      }

      public static bool operator ==(ValueCount left, ValueCount right)
      {
         return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.Equals(right);
      }

      public static bool operator !=(ValueCount left, ValueCount right)
      {
         return !(left == right);
      }

      private void Normalize()
      {
         if (!Min.HasValue && !Max.HasValue)
         {
            Min = 0;
            Max = 1;
         }
         if (Max.HasValue && !Min.HasValue)
            Min = 0;
         if (!Max.HasValue || !Min.HasValue) return;
         var min = Min < Max ? Min : Max;
         var max = Min > Max ? Min : Max;
         Min = min;
         Max = max;
      }

      private static uint? ToNullable(int n)
      {
         return n >= 0 ? (uint?)n : null;
      }

      private string GetRegexString()
      {
         if (Min == 0 && Max == 1)
            return "?";
         if (Min == 0 && !Max.HasValue)
            return "*";
         if (Min == 1 && !Max.HasValue)
            return "+";
         if (!Min.HasValue && !Max.HasValue)
            return "?";
         return Min == Max ? string.Format("{{{0}}}", Min) : string.Format("{{{0},{1}}}", Min, Max);
      }

      public override bool Equals(object obj)
      {
         return Equals(obj as ValueCount);
      }

      public override string ToString()
      {
         return GetRegexString();
      }
   }
}