// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class Control : ElementStep
	{
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();
		public String Label { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = String.Empty;
			if (!String.IsNullOrEmpty(Label))
				xPath = $".//div[contains(@class, 'control-group')]/label/span[normalize-space()={Label.XPathText()}]/../../div[contains(@class, 'input-group')]/*";
			else if (!String.IsNullOrEmpty(TestId))
				xPath = $".//div[contains(@class, 'control-group')][@test-id='{TestId}']/div[contains(@class, 'input-group')]/*";

			var scope = control.GetElementByXPath(xPath);

			var tn = scope.TagName;
			if (tn != "input" && tn != "textarea" && tn != "span")
				throw new TestException($"Invalid element '{tn}'. Expected 'input' or 'textarea' or 'span'");

			scope.Click(checkEnabled:false);

			foreach (var step in Steps)
			{
				step.ElementRun(root, browser, scope);
			}
		}

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			throw new NotImplementedException();
		}

		public override void OnInit()
		{
			base.OnInit();
			foreach (var s in Steps)
				s.Parent = this;
		}
	}

	public class TextBox : Control
	{

	}

	public class Selector : Control
	{

	}
}
