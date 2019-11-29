// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class ComboBox : ElementStep
	{
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();
		public String Label { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = String.Empty;
			if (!String.IsNullOrEmpty(Label))
				xPath = $".//div[contains(@class, 'control-group')]/label/span[normalize-space()={Label.XPathText()}]/../../div[contains(@class, 'input-group')]/select";
			else if (!String.IsNullOrEmpty(TestId))
				xPath = $".//div[contains(@class, 'control-group')][@test-id='{TestId}']/div[contains(@class, 'input-group')]/select";

			// The <select> is hidden. A <select-wrapper> is shown instead.
			var scope = control.GetElementByXPath(xPath, checkVisibility:false);
			scope.Click();
			Thread.Sleep(10);

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
}
