// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Globalization;
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
			var txt = elem.Text;
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
			var val = elem.Text.ToDecimal();
			if (val != Number)
				throw new TestException($"Number mismatch. Actual: '{val}', expected: '{Number}'");
		}
	}

	public class EnsureDate : ElementStep
	{
		public Boolean Today { get; set; }
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			elem.Click();
			Thread.Sleep(20); // vue set focus
			var val = elem.Text.ToDate();
			if (Today) { 
				if (val != DateTime.Today)
					throw new TestException($"Date mismatch. Actual: '{val}', expected: '{DateTime.Today.ToString("dd.MM")}'");
			}
		}
	}
}
