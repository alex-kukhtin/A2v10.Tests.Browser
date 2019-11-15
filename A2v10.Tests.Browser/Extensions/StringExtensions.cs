// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Globalization;

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
	}
}
