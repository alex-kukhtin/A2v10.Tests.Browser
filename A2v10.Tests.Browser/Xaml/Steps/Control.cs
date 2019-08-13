// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]

	public class Control : Step
	{
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();
		public String Label { get; set; }

		public override void Run(IWebBrowser browser, IScope scope)
		{
			String xPath = String.Empty;
			if (!String.IsNullOrEmpty(Label))
				xPath = $".//div[contains(@class, 'control-group')]/label/span[text()={Label.XPathText()}]/../../div[contains(@class, 'input-group')]/input";
			var control = scope.GetElementByXPath(xPath);
			foreach (var step in Steps)
			{
				step.ElementRun(browser, control);
			}
		}
	}
}
