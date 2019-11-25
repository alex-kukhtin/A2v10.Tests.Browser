// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class List : ElementStepContainer
	{
		public override ITestElement FindScope(IScope scope)
		{
			String xPath = ".//ul[contains(@class, 'a2-list')]";
			return scope.GetElementByXPath(xPath);
		}
	}
}
