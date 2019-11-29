// Copyright © 2019 Alex Kukhtin. All rights reserved.


using System.Threading;

namespace A2v10.Tests.Browser.Xaml
{
	public class Disabled: ElementStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			Thread.Sleep(20); // vue set focus
							  // current pos - input
			var disabled = elem.GetAttribute("disabled");
			if (disabled != null)
				return;
			throw new TestException("Element is not disabled");
		}
	}
}
