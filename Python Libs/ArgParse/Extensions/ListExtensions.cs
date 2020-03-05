using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgParse.Extensions
{
	internal static class ListExtensions
	{
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
		{
			return ReferenceEquals(list, null) || !list.Any();
		}
		public static bool IsTrue<T>(this IEnumerable<T> list)
		{
			return !ReferenceEquals(list, null) && list.Any(it => !Equals(it, default(T)));
		}
	}
}