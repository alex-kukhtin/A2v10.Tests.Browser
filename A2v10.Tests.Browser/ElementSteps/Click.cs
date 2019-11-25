// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	public class Click: ElementStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			elem.Click();
			browser.WaitForComplete();
		}
	}
}
