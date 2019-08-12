// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class Escape : Step
	{
		public override void Run(IWebBrowser browser, IScope scope)
		{
			browser.Escape();
		}
	}
}
