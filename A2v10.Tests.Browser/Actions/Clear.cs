// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System.Threading;

namespace A2v10.Tests.Browser.Xaml
{
	public class Clear: ElementStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			elem.Clear();
			Thread.Sleep(50); // Vue
		}
	}
}
