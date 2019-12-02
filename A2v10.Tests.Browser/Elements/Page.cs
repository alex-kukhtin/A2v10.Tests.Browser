// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class Page : ElementStepContainer
	{
		public override ITestElement FindScope(IScope scope)
		{
			String xPath = $".//div[contains(@class, 'content-view')]";
			return scope.GetElementByXPath(xPath);
		}
	}
}
