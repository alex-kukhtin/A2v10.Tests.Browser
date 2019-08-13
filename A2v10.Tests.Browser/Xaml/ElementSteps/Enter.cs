// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{

	[ContentProperty("Text")]
	public class Enter: ElementStep
	{
		public override void ElementRun(IWebBrowser browser, ITestElement elem)
		{
			elem.Enter();
		}
	}
}
