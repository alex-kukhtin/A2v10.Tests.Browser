// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Threading;

namespace A2v10.Tests.Browser.Xaml
{
	public class Open : ElementStep
	{

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			if (Parent is Panel panel)
			{
				var cls = control.GetAttribute("class");
				if (cls.Contains("expanded"))
					return; // already open
				var header = control.GetElementByXPath(".//div[contains(@class,'panel-header-slot')]");
				header.Click();
				Thread.Sleep(50); // Vue
			}
		}
	}
}
