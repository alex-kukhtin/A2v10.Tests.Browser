// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public abstract class Container : Step
	{
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		protected void RunSteps(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			foreach (var step in Steps)
			{
				step.ElementRun(root, browser, control);
			}
		}
	}
}
