// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System.Collections.Generic;

namespace A2v10.Tests.Browser.Xaml
{
	public class ElementStepCollection : List<ElementStep>
	{

	}

	public abstract class ElementStep : Step
	{
		public override void Run(IWebBrowser browser, IScope scope)
		{
			throw new System.NotImplementedException();
		}

		public abstract void ElementRun(IWebBrowser browser, ITestElement control);
	}
}
