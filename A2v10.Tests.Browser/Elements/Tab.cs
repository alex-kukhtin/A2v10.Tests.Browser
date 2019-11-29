// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Threading;

namespace A2v10.Tests.Browser.Xaml
{
	public class Tab : ElementStepContainer
	{
		public String Header { get; set; }

		public override ITestElement FindScope(IScope scope)
		{
			if (Header != null)
			{
				String hPath = $".//ul[contains(@class, 'tab-header')]/li/span[normalize-space()={Header.XPathText()}]";
				var header = scope.GetElementByXPath(hPath);
				header.Click();
				Thread.Sleep(50); // vue
			}

			String xPath = ".//div[contains(@class, 'tab-content')]";
			return scope.GetElementByXPath(xPath);
		}
	}
}
