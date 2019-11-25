// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class TabPanel : ElementStepContainer
	{
		public override ITestElement FindScope(IScope scope)
		{
			String xPath = ".//div[contains(@class, 'tab-panel')]";
			return scope.GetElementByXPath(xPath);
		}
	}
}
