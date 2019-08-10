// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class EnsureDropDown : Step
	{
		public String Items { get; set; }

		public override void Run(IWebBrowser browser)
		{
			String xPath = ".//div[contains(@class, 'dropdown')][contains(@class, 'show')]/*/button";
			browser.GetElements(xPath);
		}
	}
}
