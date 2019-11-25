// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class PrintWindow : ElementStep
	{
		public PrintStepCollection Steps { get; set; } = new PrintStepCollection();


		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			IPrintWindow newWindow = browser.GetPrintWindow();
			try
			{
				foreach (var s in Steps)
					s.ElementRun(root, browser, null);
			}
			finally
			{
				newWindow.EnsureClose();
			}
		}
	}
}
