// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	public class WaitForComplete : ElementStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			Thread.Sleep(500); // debounce
			browser.WaitForComplete();
			Thread.Sleep(50); // for Vue
		}
	}
}
