// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickButton : ElementStep
	{
		public String Text { get; set; }
		public String Icon { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = null;
			if (Text != null)
				xPath = $".//button[contains(@class,'btn')][normalize-space()={Text.XPathText()}]";
			else if (Icon != null)
				xPath = $".//button[contains(@class,'btn')]/i[contains(@class, 'ico-{Icon.ToKebabCase()}')]";
			else if (TestId != null)
				xPath = $".//button[contains(@class,'btn') and @test-id='{TestId}']";
			else
				throw new TestException("ClickButton. Attributes 'Text' or 'Icon' are required");
			browser.Click(control.GetElementByXPath(xPath));
		}
	}
}
