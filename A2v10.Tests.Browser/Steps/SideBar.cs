// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class SideBar : ElementStepContainer
	{
		public override ITestElement FindScope(IScope scope)
		{
			String xPath = ".//div[contains(@class, 'side-bar-body')]/ul[contains(@class, 'tree-view')]";
			return scope.GetElementByXPath(xPath);
		}
	}
}
