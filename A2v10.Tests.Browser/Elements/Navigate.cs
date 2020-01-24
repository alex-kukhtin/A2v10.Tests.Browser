// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class Navigate : ElementStep
	{
		public String Url { get; set; }

		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			browser.Navigate(Url.ResolveValue(root));
			Steps.ElementsRun(root, browser, control);
		}
	}
}
