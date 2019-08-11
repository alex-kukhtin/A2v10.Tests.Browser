// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class EnsureDialog : Step
	{
		public String Title { get; set; }

		public override void Run(IWebBrowser browser)
		{
			String xPath = ".//div[contains(@class, 'modal-wrapper')][contains(@class, 'show')]/div[contains(@class, 'modal-window')]";
			// TODO
			browser.GetElements(xPath);
		}
	}
}
