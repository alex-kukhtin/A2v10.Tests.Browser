// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class Confirm : Dialog
	{
		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			base.Run(root, browser, scope);
		}
	}
}
