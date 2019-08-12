// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class TypeText : Step
	{
		public String Label {get;set;}
		public String Text { get; set; }

		public override void Run(IWebBrowser browser, IScope scope)
		{
			String controlXPath = ".//div[]/div";
			var elem = scope.GetElementByXPath(controlXPath);
			elem.TypeText(Text);
		}
	}
}
