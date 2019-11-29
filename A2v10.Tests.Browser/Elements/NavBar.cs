// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class NavBar : ElementStepContainer
	{
		public override ITestElement FindScope(IScope scope)
		{
			String xPath = ".//ul[contains(@class, 'nav-bar')]";
			return scope.GetElementByXPath(xPath);
		}
	}
}
