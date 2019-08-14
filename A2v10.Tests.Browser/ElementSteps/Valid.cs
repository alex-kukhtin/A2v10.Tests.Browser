// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	public class Valid: ElementStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			// current pos - input
			var control = elem.GetElementByXPath("./../..");
			var elemClass = control.GetAttribute("class");
			if (elemClass.Contains("valid"))
				return;
			throw new TestException("Element is not valid");
		}
	}
}
