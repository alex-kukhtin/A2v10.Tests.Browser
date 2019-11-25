// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickMenuItem : ElementStep
	{
		public String Text { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = null;
			if (Text != null)
				xPath = $".//button[contains(@class,'dropdown-item')][normalize-space()={Text.XPathText()}]";
			browser.Click(control.GetElementByXPath(xPath));
		}
	}
}
