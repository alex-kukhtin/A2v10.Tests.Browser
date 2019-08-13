// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class Confirm : Dialog
	{
		public override void Run(IWebBrowser browser, IScope scope)
		{
			Thread.Sleep(100); // animation
			base.Run(browser, scope);
		}
	}
}
