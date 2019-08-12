// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class Dialog : EnsureDialog
	{
		public StepCollection Steps { get; set; } = new StepCollection();

		public override void Run(IWebBrowser browser, IScope scope)
		{
			ITestElement dialog = FindDialog(browser);

			foreach (var step in Steps)
			{
				step.Run(browser, dialog);
			}
		}
	}
}
