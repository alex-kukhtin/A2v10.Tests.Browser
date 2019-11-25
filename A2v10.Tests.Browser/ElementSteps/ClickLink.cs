// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickLink : ElementStep
	{
		public String Url { get; set; }
		public String Text { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = null;
			if (Url != null)
				xPath = $".//a[@href='{Url.Trim()}']";
			else if (Text != null)
				xPath = $".//a[normalize-space()='{Text}']";
			else if (TestId != null)
				xPath = $".//a[@test-id='{TestId}']";
			var elem = control.GetElementByXPath(xPath);
			elem.Click();
			browser.WaitForComplete();
		}
	}
}
