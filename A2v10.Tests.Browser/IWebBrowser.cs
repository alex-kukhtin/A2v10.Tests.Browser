// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;

namespace A2v10.Tests.Browser
{
	public interface IRunScenario
	{
		String Name { get; }
		String Description { get; set; }

		Exception Exception { get; }
		Boolean IsSuccess { get; }
		Boolean IsFailure { get; }

		void WriteException(Exception ex);
		void SetSuccess();
	}

	public interface IWebBrowser: IScope
	{
		void GotoUrl(String url);
		void Navigate(String url);
		void Click(ITestElement elem);
		void Escape();

		IRunScenario StartScenario(String name, String description);
	}
}
