// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class DropDown : ElementStepContainer
	{
		public override ITestElement FindScope(IScope scope)
		{
			String xPath = ".//div[contains(@class, 'dropdown')][contains(@class, 'show')]";
			if (Parent is Control)
				xPath = "./ancestor::div[contains(@class, 'input-group')]//div[contains(@class, 'dropdown')][contains(@class, 'show')]";
			return scope.GetElementByXPath(xPath);
		}
	}
}
