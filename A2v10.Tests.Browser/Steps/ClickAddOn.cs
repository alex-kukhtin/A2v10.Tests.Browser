// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickAddOn : ElementStep
	{
		public String Icon { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = null;
			if (Icon != null)
				xPath = $"./../a[contains(@class, 'add-on')]/i[contains(@class, 'ico-{Icon.ToLowerInvariant()}')]";
			browser.Click(control.GetElementByXPath(xPath));
		}
	}
}
