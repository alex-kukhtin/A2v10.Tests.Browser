﻿// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class Escape : ElementStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			browser.Escape();
		}
	}
}
