// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser
{
	public interface IWebBrowser
	{
		void GotoUrl(String url);
		void Navigate(String url);
		void ClickButton(String xPath);
		void GetElements(String xPath);
	}
}
