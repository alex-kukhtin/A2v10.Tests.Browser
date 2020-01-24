// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class SelectPeriod : ElementStep
	{
		public String Text { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			var period = control.GetElementByXPath(".//div[@class='nav-global-period']//div[@class='input-group']");
			period.Click();
			WaitClient();
			var menu = period.GetElementByXPath("./div[contains(@class, 'period-pane')]/ul[@class='period-menu']");

			String xPathItem = $"./li/a[normalize-space()={Text.XPathText()}]/..";
			var menuItem = menu.GetElementByXPath(xPathItem);
			var cls = menuItem.GetAttribute("class");
			if (cls.Contains("active"))
			{
				// already selected
				period.Click(); // close
				WaitClient();
			}
			else { 
				menuItem.Click();
				browser.WaitForComplete();
				WaitClient();
			}
		}
	}
}
