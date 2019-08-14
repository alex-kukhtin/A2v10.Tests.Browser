﻿// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ClickLink : Step
	{
		public String Url { get; set; }

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			String xPath = null;
			if (Url != null)
				xPath = $".//a[@href='{Url.Trim()}']";
			browser.Click(scope.GetElementByXPath(xPath));
		}
	}
}