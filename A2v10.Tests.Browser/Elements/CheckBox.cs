// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	public interface ICheckBoxStep
	{
		// marker
	}

	public class Checked : ElementStep, ICheckBoxStep 
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			var check = control.GetAttribute("xcheck");
			if (check?.ToLowerInvariant() != "true")
				throw new TestException("The CheckBox is not checked");
		}
	}

	public class Unchecked : ElementStep, ICheckBoxStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			var check = control.GetAttribute("xcheck");
			if (check != null)
				throw new TestException("The CheckBox is checked");
		}
	}

	public class Check : ElementStep, ICheckBoxStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			// control is <input>
			var check = control.GetAttribute("xcheck");
			if (check?.ToLowerInvariant() == "true")
				return; // already checked
			var elem = control.GetElementByXPath("./parent::label");
			elem.Click();
			WaitClient();
		}
	}

	public class Uncheck : ElementStep, ICheckBoxStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			// control is <input>
			var check = control.GetAttribute("xcheck");
			if (check == null)
				return; // already unchecked
			var elem = control.GetElementByXPath("./parent::label");
			elem.Click();
			WaitClient();
		}
	}

	public class CheckBoxRadioStepsCollection : List<ICheckBoxStep>
	{
	}


	[ContentProperty("Steps")]
	public class CheckBox : ElementStep
	{
		public CheckBoxRadioStepsCollection Steps { get; set; } = new CheckBoxRadioStepsCollection();
		public String Label { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = String.Empty;
			if (!String.IsNullOrEmpty(Label))
				xPath = $".//label[contains(@class, 'checkbox')][normalize-space()={Label.XPathText()}]/input";
			else if (!String.IsNullOrEmpty(TestId))
				xPath = $".//label[contains(@class, 'checkbox')][@test-id='{TestId}']/input";

			// The <checkbox> is hidden.
			var scope = control.GetElementByXPath(xPath, checkVisibility:false);

			foreach (var step in Steps)
			{
				if (step is ElementStep es)
					es.ElementRun(root, browser, scope);
			}
		}
	}
}
