// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ListItem : ElementStepContainer
	{
		public String Header { get; set; }
		public override ITestElement FindScope(IScope scope)
		{
			String xPath = null;
			if (Header != null)
				xPath = $".//li[contains(@class,'a2-list-item')]//div[contains(@class,'list-item-header')][normalize-space()={Header.XPathText()}]/..";
			return scope.GetElementByXPath(xPath);
		}
	}
}
