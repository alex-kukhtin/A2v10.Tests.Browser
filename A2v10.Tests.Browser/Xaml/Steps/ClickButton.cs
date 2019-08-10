// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickButton : Step
	{
		public String Text { get; set; }
		public String Id { get; set; }

		public override void Run(IWebBrowser browser)
		{
			//browser.ClickButton("");
		}
	}
}
