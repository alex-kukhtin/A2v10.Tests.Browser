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
			elem.Click();
			Thread.Sleep(20); // vue set focus
			var txt = elem.Text.Replace('\u00A0', ' ');
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
			elem.Click();
			Thread.Sleep(20); // vue set focus
			var txt = elem.Text.Replace('\u00A0', ' ').Replace(',', '.');
			if (Decimal.TryParse(txt, out Decimal val))
			{
				if (val != Number)
				{
					throw new TestException($"Number mismatch. Actual: '{val}', expected: '{Number}'");
				}
			}
			else
				throw new TestException($"Invalid number value. '{txt}'");
		}
	}
}
