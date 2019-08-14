
using System;
using System.Text;
using System.Text.RegularExpressions;

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

		static Regex _findBraces = null;

		public static String ResolveValue(this String text, IRootElement root)
		{
			if (root == null)
				throw new NullReferenceException(nameof(root));
			if (_findBraces == null)
				_findBraces = new Regex("\\[\\[(.+?)\\]\\]", RegexOptions.Compiled);
			var ms = _findBraces.Matches(text);
			if (ms.Count == 0)
				return text;
			var sb = new StringBuilder(text);
			foreach (Match m in ms)
			{
				String key = m.Groups[1].Value;
				String val = root.GetValue(key);
				sb.Replace(m.Value, val);
			}
			return sb.ToString();
		}
	}
}
