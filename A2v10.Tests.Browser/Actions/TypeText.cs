// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{

	[ContentProperty("Text")]
	public class TypeText : ElementStep
	{
		public String Text { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			elem.TypeText(Text);
		}
	}
}
