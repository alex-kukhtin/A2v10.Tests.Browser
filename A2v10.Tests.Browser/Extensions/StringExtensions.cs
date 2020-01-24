// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;
using System.Globalization;
using System.Text;

namespace A2v10.Tests.Browser.Xaml
{
	public static class StringExtensions
	{
		public static Decimal ToDecimal(this String str)
		{
			if (String.IsNullOrEmpty(str))
				return 0;
			str = str.Replace(" ", "").Replace("\u00A0", "").Replace(',', '.');
			return Convert.ToDecimal(str, CultureInfo.InvariantCulture);
		}

		public static DateTime ToDate(this String str)
		{
			if (DateTime.TryParseExact(str, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
				return dt;
			throw new TestException($"Invalid date value: {str}");
		}

		public static String ToStringFormat(this DateTime date, DateFormat fmt)
		{
			switch (fmt)
			{
				case DateFormat.Default:
					return date.ToString("dd.MM.yyyy");
				case DateFormat.DateUrl:
					return date.ToString("yyyyMMdd");
				default:
					throw new TestException($"Invalid date format: {fmt.ToString()}");
			}
		}

		public static String ToKebabCase(this String s, String delim = "-")
		{
			if (String.IsNullOrEmpty(s))
				return null;
			var b = new StringBuilder(s.Length + 5);
			for (var i = 0; i < s.Length; i++)
			{
				Char ch = s[i];
				if (Char.IsUpper(ch) && (i > 0))
				{
					b.Append(delim);
					b.Append(Char.ToLowerInvariant(ch));
				}
				else
				{
					b.Append(Char.ToLowerInvariant(ch));
				}
			}
			return b.ToString();
		}
	}
}
