// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickButton : Step
	{
		public String Text { get; set; }
		public String Icon { get; set; }

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			String xPath = null;
			if (Text != null)
				xPath = $".//button[contains(@class,'btn')][normalize-space()={Text.XPathText()}]";
			else if (Icon != null)
				xPath = $".//button[contains(@class,'btn')]/i[contains(@class, 'ico-{Icon.ToLowerInvariant()}')]";
			browser.Click(scope.GetElementByXPath(xPath));
		}
	}
}
