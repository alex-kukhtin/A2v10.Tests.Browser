// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System.Collections.Generic;

namespace A2v10.Tests.Browser.Xaml
{
	public class DataGridStepCollection : List<DataGridStep>
	{

	}

	public abstract class DataGridStep : Step
	{
		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			throw new System.NotImplementedException();
		}

		public abstract void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control);
	}
}
