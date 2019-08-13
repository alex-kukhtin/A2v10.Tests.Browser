
using System;
using System.Text;

namespace A2v10.Tests.Browser.Xaml
{
	public static class XPathExtensions
	{
		public static String XPathText(this String text)
		{
			if (text == null)
				return null;
			if (!text.Contains("'"))
				return $"'{text}'";
			var segments = text.Split('\'');
			var sb = new StringBuilder("concat(");
			foreach (var seg in segments)
			{
				sb.Append($"'{seg}',\"'\",");
			}
			sb.Remove(sb.Length - 5, 5); // remove last elem;
			sb.Append(")");
			return sb.ToString();
		}
	}
}
