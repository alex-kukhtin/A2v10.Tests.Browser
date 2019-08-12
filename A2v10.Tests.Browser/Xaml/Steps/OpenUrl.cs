// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class OpenUrl : Step
	{
		public String Url { get; set; }

		public override void Run(IWebBrowser browser, IScope scope)
		{
			browser.GotoUrl(Url);
		}
	}
}
