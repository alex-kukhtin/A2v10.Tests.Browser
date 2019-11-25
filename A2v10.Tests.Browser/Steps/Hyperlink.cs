// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class Hyperlink : ElementStepContainer
	{
		public String Url { get; set; }
		public String Text { get; set; }
		public String Icon { get; set; }

		public override ITestElement FindScope(IScope scope)
		{
			String xPath = null;
			if (Url != null)
				xPath = $".//a[@href='{Url.Trim()}']";
			else if (Text != null)
				xPath = $".//a[normalize-space()='{Text}']";
			else if (Icon != null)
				xPath = $".//a/i[contains(@class, 'ico-{Icon.ToKebabCase()}')]/..";
			return scope.GetElementByXPath(xPath);
		}
	}
}
