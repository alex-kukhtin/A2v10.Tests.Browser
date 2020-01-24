// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class SelectCompany : ElementStep
	{
		public String Text { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			if (Text == null)
				throw new TestException("SelectCompany. The Text attribute is required");
			String xPathCompany = $".//div[contains(@class,'a2-company-btn')]";
			var comp = control.GetElementByXPath(xPathCompany);
			var btn = comp.GetElementByXPath(".//button");
			btn.Click();
			WaitClient();
			String xPathItem = $".//a[contains(@class,'dropdown-item')]//span[contains(@class,'company-menu-name')][normalize-space()={Text.XPathText()}]/..";
			var menuItem = comp.GetElementByXPath(xPathItem);

			var icon = menuItem.GetElementByXPath("./i[contains(@class, 'ico')]", checkVisibility:false);
			var cls = icon.GetAttribute("class");
			if (cls.Contains("ico-check"))
			{
				/*already selected*/
				btn.Click();
				WaitClient();
			}
			else
			{
				menuItem.Click();
				browser.WaitForComplete();
				WaitClient();
			}
		}
	}
}
