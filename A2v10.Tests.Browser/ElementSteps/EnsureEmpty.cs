// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{

	public class EnsureEmpty : ElementStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			Thread.Sleep(20); // vue set focus
			var txt = elem.Text.Trim();
			if (!String.IsNullOrEmpty(txt))
				throw new TestException($"Text mismatch. Actual: '{txt}', expected: empty");
		}
	}
}
