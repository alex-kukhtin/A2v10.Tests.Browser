// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickButton : Step
	{
		public String Text { get; set; }

		public override void Run(IWebBrowser browser, IScope scope)
		{
			String xPath = null;
			if (Text != null)
				xPath = $".//button[contains(@class,'btn')][normalize-space()='{Text}']";
			browser.Click(scope.GetElementByXPath(xPath));
		}
	}
}
