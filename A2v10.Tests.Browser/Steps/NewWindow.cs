// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class NewWindow : Step
	{
		public String Title { get; set; }
		public String Url { get; set; }

		public StepCollection Steps { get; set; } = new StepCollection();

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			IWindow newWindow = browser.GetLastNewWindow();
			try
			{
				if (!String.IsNullOrEmpty(Title))
					if (newWindow.Title != Title)
						throw new TestException($"Invalid window title. Actual:'{newWindow.Title}', expected: '{Title}'");

				if (!String.IsNullOrEmpty(Url))
					if (newWindow.Url != Url)
						throw new TestException($"Invalid window url. Actual:'{newWindow.Url}', expected: '{Url}'");

				foreach (var step in Steps)
				{
					step.Run(root, browser, newWindow);
				}
			}
			finally {
				newWindow.Close();
			}
		}
	}
}
