// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class SelectorPane: ElementStep
	{
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			// current pos - input (debounce!)
			Thread.Sleep(50); // Vue
			var pane = elem.GetElementByXPath("./../div[contains(@class, 'selector-pane')]");
			foreach (var s in Steps)
			{
				s.ElementRun(root, browser, pane);
			}
		}
	}
}
