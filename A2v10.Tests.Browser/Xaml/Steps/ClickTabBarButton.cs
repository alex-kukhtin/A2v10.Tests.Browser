// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickTabBarButton : Step
	{
		public String Text { get; set; }

		public override void Run(IWebBrowser browser, IScope scope)
		{
			String xPath = null;
			if (Text != null)
				xPath = $".//div[contains(@class,'a2-tab-bar-item')]/a[contains(@class,'a2-tab-button')]/span[contains(@class,'content')][normalize-space()='{Text}']";
			browser.Click(scope.GetElementByXPath(xPath));
		}
	}
}
