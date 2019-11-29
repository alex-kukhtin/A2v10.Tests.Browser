// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class Panel : ElementStepContainer
	{
		public override ITestElement FindScope(IScope scope)
		{
			String xPath = null;
			if (!String.IsNullOrEmpty(TestId))
				xPath = $".//div[contains(@class, 'panel') and @test-id='{TestId}']";
			return scope.GetElementByXPath(xPath);
		}
	}
}
