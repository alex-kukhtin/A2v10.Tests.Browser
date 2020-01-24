// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{

	[ContentProperty("Text")]
	public class EnsureText : ElementStep
	{
		public String Text { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			WaitClient();
			var tagName = elem.TagName;
			var txt = elem.Text;
			if (tagName == "textarea")
				txt = elem.GetAttribute("value");
			else if (tagName == "select")
			{
				txt = elem.GetElementByXPath("./../div[@class='select-wrapper']")?.Text;
			}
			if (txt != Text)
				throw new TestException($"Text mismatch. Actual: '{txt}', expected: '{Text}'");
		}
	}

	[ContentProperty("Number")]
	public class EnsureNumber : ElementStep
	{
		public Decimal Number { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			var dis = elem.GetAttribute("disabled");
			if (dis == null)
			{
				elem.Click();
				WaitClient();
			}
			var val = elem.Text.ToDecimal();
			if (val != Number)
				throw new TestException($"Number mismatch. Actual: '{val}', expected: '{Number}'");
		}
	}

	public class EnsureDate : ElementStep
	{
		public Boolean Today { get; set; }
		public String Date { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			var dis = elem.GetAttribute("disabled");
			if (dis == null)
			{
				elem.Click();
				WaitClient();
			}
			var val = elem.Text.ToDate();
			if (Today)
			{
				if (val != DateTime.Today)
					throw new TestException($"Date mismatch. Actual: '{val}', expected: '{DateTime.Today.ToString("dd.MM.yyyy")}'");
			}
			else if (!String.IsNullOrEmpty(Date))
			{
				if (val != Date.ToDate())
					throw new TestException($"Date mismatch. Actual: '{val}', expected: '{Date}'");
			}
		}
	}
}
