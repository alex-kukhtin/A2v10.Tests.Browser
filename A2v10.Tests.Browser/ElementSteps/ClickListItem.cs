// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickListItem : ElementStep
	{
		public String Header { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = null;
			if (Header != null)
				xPath = $".//li[contains(@class,'a2-list-item')]//div[contains(@class,'list-item-header')][normalize-space()={Header.XPathText()}]";
			var elem = control.GetElementByXPath(xPath);
			elem.Click();
			browser.WaitForComplete();
		}
	}
}
