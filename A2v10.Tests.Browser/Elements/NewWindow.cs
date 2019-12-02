// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class NewWindow : ElementStep
	{
		public String Title { get; set; }
		public String Url { get; set; }

		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();


		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			IWindow newWindow = browser.GetLastNewWindow();
			try
			{
				if (!String.IsNullOrEmpty(Title))
					if (newWindow.Title != Title)
						throw new TestException($"Invalid window title. Actual:'{newWindow.Title}', expected: '{Title}'");

				if (!String.IsNullOrEmpty(Url))
					if (newWindow.Url.ToLowerInvariant() != Url.ToLowerInvariant())
						throw new TestException($"Invalid window url. Actual:'{newWindow.Url}', expected: '{Url}'");

				var scope = newWindow.GetElementsByClassName("shell")[0];

				Steps.ElementsRun(root, browser, scope);
			}
			finally
			{
				newWindow.Close();
			}
		}
	}
}
