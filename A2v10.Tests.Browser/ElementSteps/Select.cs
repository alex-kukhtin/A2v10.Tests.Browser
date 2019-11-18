// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Text")]
	public class Select: ElementStep
	{
		public String Text { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			// current = selector pane
			String xPath = String.Empty;
			if (!String.IsNullOrEmpty(Text))
				xPath = $"./div[@class='selector-body']/ul[@class='selector-ul']/li[normalize-space()='{Text}']";
			var item = elem.GetElementByXPath(xPath);
			item.Click();
		}
	}

	[ContentProperty("Text")]
	public class SelectRow : ElementStep
	{
		public String Text { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			// current = selector pane
			String xPath = String.Empty;
			if (!String.IsNullOrEmpty(Text))
				xPath = $"./div[@class='selector-body']//table//td/span[normalize-space()='{Text}']";
			var item = elem.GetElementByXPath(xPath);
			item.Click();
		}
	}
}
