// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{

	[ContentProperty("Text")]
	public class EnterText : ElementStep
	{
		public String Text { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			var active = browser.ActiveElement();
			if (!active.IsSame(elem))
			{
				elem.Click();
				WaitClient();
			}
			elem.TypeText(Text);
			elem.Enter();
		}
	}
}
