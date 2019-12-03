// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{

	[ContentProperty("Steps")]
	public class Button : ElementStep
	{
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		public String Text { get; set; }
		public String Icon { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = String.Empty;
			if (Text != null)
				xPath = $".//button[contains(@class, 'btn')][normalize-space()={Text.XPathText()}]";
			else if (TestId != null)
				xPath = $".//button[contains(@class, 'btn')][@test-id='{TestId}']";
			else if (Icon != null)
				xPath = $".//button[contains(@class,'btn')]/i[contains(@class, 'ico-{Icon.ToKebabCase()}')]";
			else
				throw new TestException("Button. Attributes 'Text', 'TextId' or 'Icon' are required");

			var scope = control.GetElementByXPath(xPath);

			foreach (var step in Steps)
				step.ElementRun(root, browser, scope);
		}

		public override void OnInit()
		{
			base.OnInit();
			foreach (var s in Steps)
				s.Parent = this;
		}
	}
}
