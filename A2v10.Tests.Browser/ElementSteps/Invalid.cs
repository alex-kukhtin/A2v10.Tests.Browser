// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Message")]
	public class Invalid: ElementStep
	{
		public String Message { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			// current pos - input
			var control = elem.GetElementByXPath("./../..");
			var elemClass = control.GetAttribute("class");
			if (!elemClass.Contains("invalid"))
				throw new TestException("Element is valid");
			String xPath = String.Empty;
			if (!String.IsNullOrEmpty(Message))
				xPath = $"./../div[@class='validator']/span[text()={Message.XPathText()}]";
			elem.GetElementByXPath(xPath, checkVisibility:false);
		}
	}
}
